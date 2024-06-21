/// Copyright 2022
/// @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
/// @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
/// @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
/// @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
///
/// Universidad de Costa Rica. CC BY 4.0
#include <string>

#include "HttpConnectionHandler.hpp"
#include "Log.hpp"

HttpConnectionHandler::HttpConnectionHandler() {
}

HttpConnectionHandler::~HttpConnectionHandler() {
  for (size_t index = 0; index < httpResponses.size(); ++index) {
    delete httpResponses.at(index);
  }
}

HttpConnectionHandler::HttpConnectionHandler(Queue<Socket>* consumingQueue) {
  this->consumingQueue = consumingQueue;
}
int HttpConnectionHandler::run() {
  this->consumeForever();
  // Send stop condition
  this->produce(HttpSocketData());
  return EXIT_SUCCESS;
}

void HttpConnectionHandler::consume(Socket workingSocket) {
  std::vector<HttpRequest*> httpRequests;
  // Client responses
  while (true) {
    // Create an object that parses the HTTP request from the socket
    HttpRequest* httpRequest = new HttpRequest(workingSocket);
    httpRequests.push_back(httpRequest);

    // If the request is not valid or an error happened
    if (!httpRequest->parse()) {
      // Non-valid requests are normal after a previous valid request. Do not
      // close the connection yet, because the valid request may take time to
      // be processed. Just stop waiting for more requests
      break;
    }
    // A complete HTTP client request was received. Create an object for the
    // server responds to that client's request
    HttpResponse* httpResponse = new HttpResponse(workingSocket);
    httpResponses.push_back(httpResponse);

    // Give subclass a chance to respond the HTTP request
    const bool handled = this->handleHttpRequest(httpResponse
      , httpRequest);

    // If subclass did not handle the request or the client used HTTP/1.0
    if (!handled || httpRequest->getHttpVersion() == "HTTP/1.0") {
      // The socket will not be more used, close the connection
      workingSocket.close();
      break;
    }
  }
  for (size_t index = 0; index < httpRequests.size(); ++index) {
    delete httpRequests.at(index);
  }
}

bool HttpConnectionHandler::handleHttpRequest(HttpResponse* httpResponse
  , HttpRequest* httpRequest) {
  // Print IP and port from client
  const NetworkAddress& address = httpRequest->getNetworkAddress();
  Log::append(Log::INFO, "connection",
    std::string("connection established with client ") + address.getIP()
    + " port " + std::to_string(address.getPort()));

  // Print HTTP request
  Log::append(Log::INFO, "request", httpRequest->getMethod()
    + ' ' + httpRequest->getURI()
    + ' ' + httpRequest->getHttpVersion());
  // Create data to send to the dispatcher
  HttpSocketData httpSocketData;
  httpSocketData.httpRequest = httpRequest;
  httpSocketData.httpResponse = httpResponse;
  // Produce socket data for the dispatcher
  this->produce(httpSocketData);
  return true;
}
