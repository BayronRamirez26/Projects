/// Copyright 2022
/// @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
/// @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
/// @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
/// @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
///
/// Universidad de Costa Rica. CC BY 4.0

#ifndef HTTPCONNECTIONHANDLER_HPP
#define HTTPCONNECTIONHANDLER_HPP

#include <vector>
#include "Assembler.hpp"
#include "HttpApp.hpp"
#include "HttpRequest.hpp"
#include "HttpResponse.hpp"
#include "HttpSocketData.hpp"
#include "Log.hpp"
#include "NetworkAddress.hpp"
#include "Socket.hpp"

/// @brief HttpConnectionHandler class
/// @details Class in charge of handling client request
class HttpConnectionHandler : public Assembler<Socket, HttpSocketData> {
  DISABLE_COPY(HttpConnectionHandler);

 protected:
  /// Vector of httpResponses created
  std::vector<HttpResponse*> httpResponses;

 public:
  /// Constructor
  HttpConnectionHandler();
  /// Destructor
  ~HttpConnectionHandler();
  /// Constructor
  /// @param consumingQueue
  explicit HttpConnectionHandler(Queue<Socket>* consumingQueue);
  /// Sets the socket to work on the class.
  /// Consume the messages in its own execution thread.
  int run() override;

  /// Method that is in charge of processing sockets.
  /// @param workingSocket socket to process.
  void consume(Socket workingSocket) override;
  /// Called each time an HTTP request is received. Web server should analyze
  /// the request object and assemble a response with the response object.
  /// Finally send the response calling the httpResponse.send() method.
  /// @return true on success and the server will continue handling further
  /// HTTP requests, or false if server should stop accepting requests from
  /// this client (e.g: HTTP/1.0)
  bool handleHttpRequest(HttpResponse* httpResponse, HttpRequest* httpRequest);
};

#endif  // HTTPCONNECTIONHANDLER_HPP
