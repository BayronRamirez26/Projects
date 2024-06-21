/// Copyright 2022
/// @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
/// @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
/// @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
/// @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
///
/// Universidad de Costa Rica. CC BY 4.0

#include "GoldSender.hpp"
#include <iostream>

GoldSender::GoldSender() { }

GoldSender::~GoldSender() { }

int GoldSender::run() {
  // Start the forever loop to consume all the messages that arrive
  this->consumeForever();

  // If the forever loop finished, no more messages will arrive
  // Print statistics
  return EXIT_SUCCESS;
}

void GoldSender::consume(GoldBodyResponse data) {
  // Set HttpResponse body
  data.httpResponse->body().str(data.body);
  data.httpResponse->send();
}
