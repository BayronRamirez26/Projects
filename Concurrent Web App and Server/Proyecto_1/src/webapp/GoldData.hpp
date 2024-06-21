/// Copyright 2022
/// @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
/// @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
/// @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
/// @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
///
/// Universidad de Costa Rica. CC BY 4.0

#ifndef GOLDDATA_HPP
#define GOLDDATA_HPP

#include <string>
#include <vector>

#include "HttpRequest.hpp"
#include "HttpResponse.hpp"
#include "GoldbachNumber.hpp"

/**
 * @brief Struct that contains the data to form the goldbach sums
 * 
 */
struct GoldData {
  /// Request for the goldbach sums
  int64_t number = 0;
  /// Order in which the number was requested
  int64_t priority = -1;
  /// Amount of numbers in the request
  size_t numberCount = 0;
  /// Global total sums
  int64_t global_total_sums = 0;
  /// Result of the goldbach sums
  GoldbachNumber* sums = nullptr;
  /// Clients request for the page
  HttpRequest* httpRequest = nullptr;
  /// Client to send the response
  HttpResponse* httpResponse = nullptr;
  /// Sums output
  std::vector<GoldbachNumber*>* outputs = nullptr;
  /// Inputs inputs
  std::vector<int64_t>* inputs = nullptr;
  /// Boolean to indicate matches of regex were valid
  bool validRequest = true;
  /// Flag to indicate if the requested page is the homepage
  bool isHomePage = false;
  /// Server was not found
  bool serveNotFound = false;
  /// Overload of == operator
  inline bool operator==(const GoldData& goldData) const {
    return goldData.number == this->number
      && goldData.sums == this->sums
      && goldData.httpRequest == this->httpRequest
      && goldData.httpResponse == this->httpResponse
      && goldData.priority == this->priority
      && goldData.numberCount == this->numberCount
      && goldData.outputs == this->outputs
      && goldData.inputs == this->inputs
      && goldData.global_total_sums == this->global_total_sums
      && goldData.validRequest == this->validRequest
      && goldData.isHomePage == this->isHomePage
      && goldData.serveNotFound == this->serveNotFound;
  }
};

#endif  // GOLDDATA_HPP
