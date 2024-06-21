/// Copyright 2022
/// @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
/// @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
/// @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
/// @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
///
/// Universidad de Costa Rica. CC BY 4.0

#ifndef HTTPCONNECTIONDISPATCHER_HPP
#define HTTPCONNECTIONDISPATCHER_HPP

#include <vector>
#include <string>
#include "Dispatcher.hpp"
#include "HttpRequest.hpp"
#include "HttpResponse.hpp"
#include "HttpSocketData.hpp"
#include "HttpApp.hpp"
#include "Log.hpp"
#include "Socket.hpp"

/**
 * @brief HttpConnectionDispatcher class
 * @details Class in charge of sending HttpSocketData to the respective
 * application
 */
class HttpConnectionDispatcher : public Dispatcher<std::string
  , HttpSocketData> {
  DISABLE_COPY(HttpConnectionDispatcher);
 protected:
  /// Applications vector
  std::vector<HttpApp*> applications;
  /// Amount of connection handlers
  size_t handlersAmount = 0;
 public:
  /// Constructor
  HttpConnectionDispatcher();
  /// Destructor
  virtual ~HttpConnectionDispatcher();
  /// Start redirecting network messages
  int run() override;
  /// This method extracts the key from a data stored in the fromQueue
  std::string extractKey(HttpSocketData& data) const override;
  /// Look for the corresponding application identifier.
  std::string findKey(std::string url) const;
  /// Sets the amount of connection handlers
  void setHandlersAmount(size_t handlersAmount);
};
#endif  // HTTPCONNECTIONDISPATCHER_HPP
