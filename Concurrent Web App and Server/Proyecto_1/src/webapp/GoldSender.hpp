/// Copyright 2022
/// @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
/// @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
/// @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
/// @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
///
/// Universidad de Costa Rica. CC BY 4.0

#ifndef GOLDSENDER_HPP
#define GOLDSENDER_HPP

#include <vector>
#include <string>

#include "HttpApp.hpp"
#include "Consumer.hpp"
#include "GoldBodyResponse.hpp"
#include "GoldUtils.hpp"
#include "Log.hpp"

/**
 * @brief Class GoldSender
 * @details Class in charge of sending the client response
 */
class GoldSender : public Consumer<GoldBodyResponse> {
 public:
  /// Constructor
  GoldSender();
  /// Destructor
  ~GoldSender();
  /// Consume the messages in its own execution thread
  int run() override;
  /// Override this method to process any data extracted from the queue
  void consume(GoldBodyResponse data) override;
};

#endif  // GOLDSENDER_HPP
