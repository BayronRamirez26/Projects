// Copyright 2021 Jeisson Hidalgo-Cespedes. Universidad de Costa Rica. CC BY 4.0

#include <algorithm>
#include <cassert>
#include <iostream>
#include <stdexcept>
#include <cstdlib>

#include "GoldWebApp.hpp"
#include "HttpRequest.hpp"
#include "HttpResponse.hpp"

GoldWebApp& GoldWebApp::getInstance() {
  static GoldWebApp goldWebApp;
  return goldWebApp;
}

GoldWebApp::GoldWebApp() {
  this->identifier = "/gold";
}

GoldWebApp::~GoldWebApp() {
  delete this->urlAnalizer->getProducingQueue();
  delete this->urlAnalizer;
  int processor_count = std::thread::hardware_concurrency();
  for (int index = 0; index < processor_count; index++) {
    delete this->solvers[index];
  }
  delete this->packer;
  delete this->bodyCreator;
  delete this->sender;
}

void GoldWebApp::start() {
  // TODO(you): Start producers, consumers, assemblers...
  const unsigned int processor_count = std::thread::hardware_concurrency();
  // Create objects for the web app
  this->urlAnalizer = new GoldUrlAnalizer();
  solvers.resize(processor_count);
  for (size_t index = 0; index < processor_count; ++index) {
    this->solvers[index] = new GoldSolver();
  }
  this->packer = new GoldPacker();
  this->bodyCreator = new GoldBodyCreator();
  this->sender = new GoldSender();
  // Create queues
  // UrlAnalizer needs its own consuming queue and its own producing queue for
  // the solvers consumng queue
  this->urlAnalizer->createOwnQueue();
  this->urlAnalizer->setProducingQueue(new Queue<GoldData>());
  this->packer->createOwnQueue();
  this->bodyCreator->createOwnQueue();
  this->sender->createOwnQueue();
  this->receiverQueue = this->urlAnalizer->getConsumingQueue();

  // Communicate web app objects
  // App enqueues to the url analizer queue
  // Solvers consume from the urlAnalizer and produce to the packer
  for (size_t index = 0; index < processor_count; ++index) {
    this->solvers[index]->setConsumingQueue
      (this->urlAnalizer->getProducingQueue());
    this->solvers[index]->setProducingQueue
      (this->packer->getConsumingQueue());
  }
  // Packer consumes from the solvers and produces to the body creator
  this->packer->setProducingQueue(this->bodyCreator->getConsumingQueue());
  // Body creator consumes from the packer and produces to the sender
  this->bodyCreator->setProducingQueue(this->sender->getConsumingQueue());

  // Start the web app
  this->urlAnalizer->startThread();
  for (size_t index = 0; index < processor_count; ++index)
    this->solvers[index]->startThread();
  this->packer->startThread();
  this->bodyCreator->startThread();
  this->sender->startThread();
  // Simulation finished
}

void GoldWebApp::stop() {
  // TODO(you): Stop producers, consumers, assemblers...
  const unsigned int processor_count = this->solvers.size();
  // Wait for objets to finish
  this->urlAnalizer->waitToFinish();
  for (size_t index = 0; index < processor_count; ++index) {
    this->solvers[index]->waitToFinish();
  }
  this->packer->waitToFinish();
  this->bodyCreator->waitToFinish();
  this->sender->waitToFinish();
  Log::append(Log::INFO, "WebApp", "WebApp finished");
}
