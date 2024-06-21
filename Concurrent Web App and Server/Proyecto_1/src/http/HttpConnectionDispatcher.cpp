/// Copyright 2022
/// @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
/// @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
/// @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
/// @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
///
/// Universidad de Costa Rica. CC BY 4.0

#include "HttpConnectionDispatcher.hpp"

HttpConnectionDispatcher::HttpConnectionDispatcher() {}

HttpConnectionDispatcher::~HttpConnectionDispatcher() {}

int HttpConnectionDispatcher::run() {
  // Consume from all connection handlers
  for (size_t index = 0; index < this->handlersAmount; ++index) {
    this->consumeForever();
  }
  // If we exited from the forever loop, the finish message was received
  // For this simulation is OK to propagate it to all the queues
  for ( const auto& pair : this->toQueues ) {
    pair.second->push(HttpSocketData());
  }
  return EXIT_SUCCESS;
}

/// This method extracts the key from a data stored in the fromQueue
std::string HttpConnectionDispatcher::extractKey(HttpSocketData& data)
  const {
  // Find the key in the url
  std::string key = this->findKey(data.httpRequest->getURI());
  const auto& itr = this->toQueues.find(key);
  if ( itr == this->toQueues.end() ) {  // Request not found. Send to first app
    data.serveNotFound = true;
    return this->toQueues.begin()->first;
  }
  return key;
}

std::string HttpConnectionDispatcher::findKey(std::string url) const {
  if (url.compare("/") == 0 || url.compare("/favicon.ico") == 0) {
    // Search homepage. Send it to the first app
    return this->toQueues.begin()->first;
  }
  int pos1 = url.find('/');  // find the first position to split the string
  int pos2 = 0;
  std::string sub2 = url.substr(pos1 + 1, url.length());
  // find the last position to split the sting
  if (sub2.find('/', 0) == std::string::npos) {
    pos2 = sub2.find('?');
  } else {
    pos2 = sub2.find('/');
  }
  std::string key = url.substr(pos1, pos2 + 1);
  return key;
}

void HttpConnectionDispatcher::setHandlersAmount(size_t handlersAmount) {
  this->handlersAmount = handlersAmount;
}
