/// Copyright 2022
/// @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
/// @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
/// @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
/// @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
///
/// Universidad de Costa Rica. CC BY 4.0

#include "GoldPacker.hpp"

#include <iostream>

GoldPacker::GoldPacker() { }

GoldPacker::~GoldPacker() { }

int GoldPacker::run() {
  // Start consuming. For all the  solvers
  for (unsigned int index = 0; index < std::thread::hardware_concurrency()
    ; ++index) {
    this->consumeForever();
  }
  // Push stop condition
  this->producingQueue->push(GoldData());
  // If the forever loop finished, no more messages will arrive
  return EXIT_SUCCESS;
}

void GoldPacker::consume(GoldData data) {
  if (data.isHomePage || !data.validRequest || data.serveNotFound) {
    this->produce(data);
  } else {
    // If conditions are meet up then push. Otherwise do nothing
    int64_t index = searchIndexClient(data.httpResponse);
    if (index == -1) {  // New client
      // Append new client
      this->clients.push_back(data.httpResponse);
      index = this->clients.size()-1;
      // Create new reponse vector for the client
      this->packedAnswers.emplace_back(std::vector<GoldbachNumber*>());
      this->receivedNumbers.push_back(1);

      // Resize that vector to the size of the number
      this->packedAnswers[index].resize(data.numberCount);

      // Append the sums of the number to the response vector
      this->packedAnswers[index][data.priority] = data.sums;
    } else {  // Old client
      // Append the sums of the number to the response vector
      this->packedAnswers[index][data.priority] = data.sums;
      ++this->receivedNumbers[index];
    }
    // Package ready to be send
    if (this->receivedNumbers[index] == data.numberCount) {
      // Produce goldbach response
      data.outputs
        = new std::vector<GoldbachNumber*>(this->packedAnswers[index]);
      // Push to producing queue
      this->produce(data);
    }
  }
}

size_t GoldPacker::searchIndexClient(HttpResponse* client) {
  for (size_t index = 0; index < this->clients.size(); ++index) {
    if (client == clients[index]) {
      return index;  // Client found
    }
  }
  // Not found
  return -1;
}
