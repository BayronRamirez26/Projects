/// Copyright 2022
/// @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
/// @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
/// @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
/// @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
///
/// Universidad de Costa Rica. CC BY 4.0
#ifndef HTTP_SOCKET_DATA_HPP
#define HTTP_SOCKET_DATA_HPP

#include "HttpResponse.hpp"
#include "HttpRequest.hpp"

/**
 * @brief Struct containg a response and answer of a Socket
 */
struct HttpSocketData {
  /// Request of the socket
  HttpRequest* httpRequest = nullptr;
  /// Response of the socket
  HttpResponse* httpResponse = nullptr;
  /// Boolean to know if the server was not found
  bool serveNotFound = false;
  /// Overload of == operator
  inline bool operator==(const HttpSocketData& httpSocketData) const {
    return httpSocketData.httpRequest == this->httpRequest
      && httpSocketData.httpResponse == this->httpResponse
      && httpSocketData.serveNotFound == this->serveNotFound;
  }
};

#endif  // HTTP_SOCKET_DATA_HPP
