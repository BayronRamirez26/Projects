/// Copyright 2022
/// @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
/// @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
/// @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
/// @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
///
/// Universidad de Costa Rica. CC BY 4.0

#ifndef GOLDPACKER_HPP
#define GOLDPACKER_HPP

#include <vector>

#include "Assembler.hpp"
#include "GoldData.hpp"
#include "GoldbachNumber.hpp"
#include "Log.hpp"

/**
 * @brief Class GoldPacker
 * @details Class in charge of packing the reponses for the clients
 */
class GoldPacker : public Assembler<GoldData, GoldData> {
 protected:
  /// Clients vector
  std::vector<HttpResponse*> clients;
  /// Vector of received numbers count for each client
  std::vector<size_t> receivedNumbers;
  /// Packed answers vector
  std::vector<std::vector<GoldbachNumber*>> packedAnswers;
  /// Metod that gets the index of a client and returns
  /// @brief client client to search
  /// @return size_t index of the client
  size_t searchIndexClient(HttpResponse* client);

 public:
  /// Constructor
  GoldPacker();
  /// Destructor
  ~GoldPacker();
  /// Consume the messages in its own execution thread
  int run() override;
  /// Override this method to process any data extracted from the queue
  void consume(GoldData data) override;
};

#endif  // GOLDPACKER_HPP
