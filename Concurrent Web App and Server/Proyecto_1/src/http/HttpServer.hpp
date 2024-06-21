// Copyright 2021 Jeisson Hidalgo-Cespedes. Universidad de Costa Rica. CC BY 4.0

#ifndef HTTPSERVER_H
#define HTTPSERVER_H

#include <thread>
#include <vector>

#include "HttpConnectionDispatcher.hpp"
#include "HttpConnectionHandler.hpp"
#include "HttpRequest.hpp"
#include "HttpResponse.hpp"
#include "Queue.hpp"
#include "TcpServer.hpp"

#define DEFAULT_PORT "8080"

class HttpApp;

/// @brief class HttpServer.
/// @details this class chains webapps and answers clients requests through
/// sockets.
class HttpServer : public TcpServer {
  DISABLE_COPY(HttpServer);

 protected:
  /// Lookup criteria for searching network information about this host
  struct addrinfo hints;
  /// TCP port where this web server will listen for connections
  const char* port = DEFAULT_PORT;
  /// Chain of registered web applications. Each time an incoming HTTP request
  /// is received, the request is provided to each application of this chain.
  /// If an application detects the request is for it, the application will
  /// call the httpResponse.send() and the chain stops. If no web app serves
  /// the request, the not found page will be served.
  std::vector<HttpApp*> applications;
  /// Vector of connection handlers
  std::vector<HttpConnectionHandler*> connectionHandlers;
  /// Connection dispatcher
  HttpConnectionDispatcher* connectionDispatcher = nullptr;
  /// Consuming queue for the connection handlers
  Queue<Socket>* connectionHandlerQueue;
  /// Amount of desired concurrent connections
  size_t max_connections;

 public:
  /// Get access to the unique instance of HttpServer. Singleton design
  static HttpServer& getInstance();
  /// Registers a web application to the chain
  void chainWebApp(HttpApp* application);
  /// Start the web server for listening client connections and HTTP requests
  int start(int argc, char* argv[]);
  /// Stop the web server. The server may stop not immediately. It will stop
  /// for listening further connection requests at once, but pending HTTP
  /// requests that are enqueued will be allowed to finish
  void stop();
  /// Infinetelly listen for client connection requests and accept all of them.
  /// For each accepted connection request, the virtual onConnectionAccepted()
  /// will be called. Inherited classes must override that method
  void listenForever(const char* port);

 protected:
  /// Analyze the command line arguments
  /// @return true if program can continue execution, false otherwise
  bool analyzeArguments(int argc, char* argv[]);
  /// This method is called each time a client connection request is accepted.
  void handleClientConnection(Socket& client) override;
  /// Static method that gets the web server instance and asks it to stop.
  /// @param signum number of signal sent.
  static void signal_handler(int signum);
  /// Creates the request connection handlers
  void createConnectionHandlers();
  /// Starts the connection handlers
  void startConnectionHandlers();
  /// Waits for connection handlers to close
  void waitForConnectionHandlers();
  /// Starts the aplications
  void startApplications();
  /// Waits for applications to close
  void waitForApplications();
 private :
  /// Constructor
  HttpServer();
  /// Destructor
  ~HttpServer();
};

#endif  // HTTPSERVER_H
