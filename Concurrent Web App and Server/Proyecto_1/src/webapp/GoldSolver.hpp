/// Copyright 2022
/// @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
/// @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
/// @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
/// @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
///
/// Universidad de Costa Rica. CC BY 4.0

#ifndef GOLDSOLVER_HPP
#define GOLDSOLVER_HPP

#include "Assembler.hpp"
#include "GoldData.hpp"
#include "Goldbach.hpp"
#include "Log.hpp"

/**
 * @brief Class GoldSolver
 * @details Class in charge of solving goldbach sums for a number
 */
class GoldSolver : public Assembler<GoldData, GoldData> {
  DISABLE_COPY(GoldSolver);
 protected:
  /// Instance of goldbach calculator
  Goldbach* goldbachCalculator;
 public:
  /// Constructor
  GoldSolver();
  /// Destructor
  ~GoldSolver();
  /// Consume the messages in its own execution thread
  int run() override;
  /// Override this method to process any data extracted from the queue
  void consume(GoldData data) override;
};

#endif  // GOLDSOLVER_HPP
