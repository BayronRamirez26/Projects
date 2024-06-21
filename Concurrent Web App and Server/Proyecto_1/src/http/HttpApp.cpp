// Copyright 2021 Jeisson Hidalgo-Cespedes. Universidad de Costa Rica. CC BY 4.0

#include "HttpApp.hpp"

void HttpApp::start() {
  // Default base class implementation does nothing
}

void HttpApp::stop() {
  // Default base class implementation does nothing
}

void HttpApp::setIdentifier(std::string identifier) {
  this->identifier = identifier;
}

std::string HttpApp::getIdentifier() const {
  return this->identifier;
}

Queue<HttpSocketData>* HttpApp::getReceiverQueue() const {
  return this->receiverQueue;
}
