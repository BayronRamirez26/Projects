// Copyright 2021 Jeisson Hidalgo-Cespedes. Universidad de Costa Rica. CC BY 4.0
#include "HttpServer.hpp"
#include <cassert>
#include <stdexcept>
#include <string>
#include <csignal>

#include "HttpApp.hpp"
#include "HttpConnectionHandler.hpp"
#include "HttpRequest.hpp"
#include "HttpResponse.hpp"
#include "Log.hpp"
#include "NetworkAddress.hpp"
#include "Socket.hpp"


const char* const usage =
  "Usage: webserv [port] [handlers]\n"
  "\n"
  "  port        Network port to listen incoming HTTP requests, default "
    DEFAULT_PORT "\n"
  "  handlers     Number of connection handler theads\n";

HttpServer::HttpServer() {
}

HttpServer::~HttpServer() {
  for ( size_t index = 0; index < this->max_connections; ++index ) {
    delete this->connectionHandlers[index];
  }
  delete this->connectionHandlerQueue;
  delete this->connectionDispatcher;
}

HttpServer& HttpServer::getInstance() {
  static HttpServer httpServer;
  return httpServer;
}

void HttpServer::listenForever(const char* port) {
  return TcpServer::listenForever(port);
}

void HttpServer::signal_handler(int signum) {
  assert(signum);
  HttpServer::getInstance().stop();
}

void HttpServer::handleClientConnection(Socket& client) {
  // While the same client asks for HTTP requests in the same connection
  this->connectionHandlerQueue->push(client);
}

void HttpServer::chainWebApp(HttpApp* application) {
  assert(application);
  this->applications.push_back(application);
}

int HttpServer::start(int argc, char* argv[]) {
  bool stopApps = false;
  // Boolean to know if the connection dispatcher was created
  bool startedConnDispatcher = false;
  std::signal(SIGINT, this->signal_handler);
  std::signal(SIGTERM, this->signal_handler);
  try {
    if (this->analyzeArguments(argc, argv)) {
      // Start the log service
      Log::getInstance().start();
      // Create the server components
      this->createConnectionHandlers();
      this->connectionDispatcher = new HttpConnectionDispatcher();
      this->connectionDispatcher->createOwnQueue();
      this->connectionDispatcher->setHandlersAmount(this->max_connections);
      startedConnDispatcher = true;
      // Communicate server components
      for (size_t index = 0; index < this->max_connections; ++index) {
        this->connectionHandlers[index]
          ->setProducingQueue(connectionDispatcher->getConsumingQueue());
      }
      this->startApplications();
      for ( size_t index = 0; index < this->applications.size(); ++index ) {
        this->connectionDispatcher->registerRedirect(
          applications[index]->getIdentifier()
          , applications[index]->getReceiverQueue());
      }
      // Start the parts of the consuming chain
      this->startConnectionHandlers();
      this->connectionDispatcher->startThread();
      stopApps = true;

      // Start waiting for connections
      this->listenForConnections(this->port);
      // this->listenForever(this->port);
      const NetworkAddress& address = this->getNetworkAddress();
      Log::append(Log::INFO, "webserver", "Listening on " + address.getIP()
        + " port " + std::to_string(address.getPort()));
      // Accept all client connections
      this->acceptAllConnections();
    }
  } catch (const std::runtime_error& error) {
    // Wait for threads to stop
    this->waitForConnectionHandlers();

    if (startedConnDispatcher) {
      // free dispatcher of connections
      this->connectionDispatcher->waitToFinish();
    }
    // Stop web applications. Give them an opportunity to clean up
    // If applications were started
    if (stopApps) {
      this->waitForApplications();
    }
    // Jump to next line
    std::cout << "\n";
    Log::append(Log::INFO, "Connection", "Closed connection with clients");
  }
  // Stop the log service
  Log::getInstance().stop();

  return EXIT_SUCCESS;
}

bool HttpServer::analyzeArguments(int argc, char* argv[]) {
  // Traverse all arguments
  for (int index = 1; index < argc; ++index) {
    const std::string argument = argv[index];
    if (argument.find("help") != std::string::npos) {
      std::cout << usage;
      return false;
    }
  }

  if (argc >= 2) {
    this->port = argv[1];
    if (argc == 3) {  // If thread number indicated
      try {
        this->max_connections = std::stoll(argv[2]);
      }
      catch(const std::exception& e) {  //
        // default number of CPUs
        this->max_connections = std::thread::hardware_concurrency();
      }
    } else {  // default number of CPUs
      this->max_connections = std::thread::hardware_concurrency();
    }
  }
  return true;
}

void HttpServer::stop() {
  // Stop listening for incoming client connection requests
  this->stopListening();
}

void HttpServer::waitForConnectionHandlers() {
  // Send stop conditions
  for ( size_t index = 0; index < this->max_connections; ++index ) {
    this->connectionHandlerQueue->push(Socket());
  }
  // Close all threads
  for ( size_t index = 0; index < this->max_connections; ++index ) {
    this->connectionHandlers[index]->waitToFinish();
  }
}

void HttpServer::createConnectionHandlers() {
  // Create connection handlers queue
  this->connectionHandlerQueue = new Queue<Socket>;
  // Initialize connection handlers
  this->connectionHandlers.resize(this->max_connections);
  for ( size_t index = 0; index < this->max_connections; ++index ) {
    this->connectionHandlers[index] = new HttpConnectionHandler();
    assert(this->connectionHandlers[index]);
    this->connectionHandlers[index]->
      setConsumingQueue(this->connectionHandlerQueue);
  }
}
/// Starts the connection handlers
void HttpServer::startConnectionHandlers() {
  for (size_t index = 0; index < this->max_connections; ++index) {
    this->connectionHandlers[index]->startThread();
  }
}
void HttpServer::startApplications() {
  for (size_t index = 0; index < this->applications.size(); ++index) {
    this->applications[index]->start();
  }
}

void HttpServer::waitForApplications() {
  for (size_t index = 0; index < this->applications.size(); ++index) {
    this->applications[index]->stop();
  }
}
