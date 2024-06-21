/// Copyright 2022
/// @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
/// @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
/// @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
/// @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
///
/// Universidad de Costa Rica. CC BY 4.0

#include "GoldSolver.hpp"

GoldSolver::GoldSolver() {
  // Create instance of goldbach
  this->goldbachCalculator = new Goldbach();
}

GoldSolver::~GoldSolver() {
  // Free memory
  if (this->goldbachCalculator) {
    delete goldbachCalculator;
  }
}

int GoldSolver::run() {
  // Start consuming
  this->consumeForever();
  // Push stop condition
  this->producingQueue->push(GoldData());
  // If the forever loop finished, no more messages will arrive
  // Print statistics
  return EXIT_SUCCESS;
}

void GoldSolver::consume(GoldData data) {
  if (data.isHomePage || !data.validRequest || data.serveNotFound) {
    this->produce(data);
  } else {
    // Extract number from request
    int64_t reqNumber = data.number;
    // Calculate sums
    this->goldbachCalculator->run(reqNumber);
    // Get the data for the response
    data.sums = this->goldbachCalculator->get_number_sums();
    // Produce answer
    this->produce(data);
  }
}
