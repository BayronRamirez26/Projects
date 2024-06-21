// Copyright 2021 Jeisson Hidalgo-Cespedes. Universidad de Costa Rica. CC BY 4.0

#ifndef HTTPAPP_H
#define HTTPAPP_H

#include <string>

#include "Queue.hpp"
#include "common.hpp"
#include "GoldData.hpp"
#include "HttpSocketData.hpp"
#include "Socket.hpp"


/**
 * @brief Base class for all web applications that can be registered with the
 * web server.
 */
class HttpApp {
  /// Web application objects are usually complex. This base class does not
  /// require child classes to allow copying
  DISABLE_COPY(HttpApp);

 protected:
  /// String identifier
  std::string identifier;

 public:
  /// Packs receiver queue
  Queue<HttpSocketData>* receiverQueue = nullptr;
  /// Constructor
  HttpApp() = default;
  /// Destructor
  ~HttpApp() = default;
  /// Called by the web server when the web server is started
  virtual void start();
  /*
  /// Handle HTTP requests. @see HttpServer::handleHttpRequest()
  /// @return true If this application handled the request, false otherwise
  /// and another chained application should handle it
  virtual bool handleHttpRequest(HttpRequest& httpRequest,
    HttpResponse& httpResponse) = 0;*/
  /// Called when the web server stops, in order to allow the web application
  /// clean up and finish as well
  virtual void stop();
  /// @brief Sets the identifier for app
  /// @param identifier the app identifier
  virtual void setIdentifier(std::string identifier);
  /// @brief Gets the app identifier
  virtual std::string getIdentifier() const;
  /// @brief Gets the receiver queue
  Queue<HttpSocketData>* getReceiverQueue() const;
};

#endif  // HTTPAPP_H
