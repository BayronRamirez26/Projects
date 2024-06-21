/// Copyright 2022
/// @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
/// @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
/// @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
/// @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
///
/// Universidad de Costa Rica. CC BY 4.0

#ifndef GOLDURLANALIZER_HPP
#define GOLDURLANALIZER_HPP

#include <regex>
#include <string>
#include <vector>

#include "Assembler.hpp"
#include "GoldData.hpp"
#include "HttpSocketData.hpp"
#include "Log.hpp"

/**
 * @brief GoldUrlAnalizer class
 * @details Class in charge of analizing URL parts
 */
class GoldUrlAnalizer : public Assembler <HttpSocketData, GoldData> {
 protected:
  /// Regex mutex in case many threads want to use the resource
  // std::mutex regexMutex;
  /// @brief Analizes url and extracts numbers from it
  /// @param data contains a HttpSocketData
  /// @param goldData contains the data to form the goldbach sums
  void analizeUrl(HttpSocketData& data, GoldData& goldData);
  /// @brief Split a string.
  /// @param answers vector with the results of the string splitted.
  /// @param string string that we want to split.
  /// @param delimiter where you want to split the string.
  /// @return vector containing the results of the split
  std::vector<std::string>& split(std::vector<std::string>& answers,
  std::string string, std::string delimiter);
  /// @brief Parses the matches from regex to obtain numbers
  /// @param results vector of integers containing the matches parsing
  /// @param matches teh matches from regex
  void parseMatches(std::vector<int64_t>& results, std::smatch& matches);

 public:
  /// Constructor
  GoldUrlAnalizer();
  /// Destructor
  ~GoldUrlAnalizer();
  /// Consume the messages in its own execution thread
  int run() override;
  /// Override this method to process any data extracted from the queue
  void consume(HttpSocketData data) override;
};

#endif  // GOLDURLANALIZER_HPP
