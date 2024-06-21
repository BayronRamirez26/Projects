/// Copyright 2022
/// @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
/// @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
/// @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
/// @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
///
/// Universidad de Costa Rica. CC BY 4.0

#ifndef GOLDBODYRESPONSE_HPP
#define GOLDBODYRESPONSE_HPP

#include <string.h>
#include <string>

#include "HttpResponse.hpp"

/**
 * @brief GoldBodyResponse struct
 * @details Contains a client response for goldbach.
 *
 */
struct GoldBodyResponse {
  /// Request for the goldbach sums
  std::string body = "";
  /// Client to send the response
  HttpResponse* httpResponse = nullptr;
  /// Overload of == operator
  inline bool operator==(const GoldBodyResponse& goldBodyResponse) const {
    return goldBodyResponse.body.compare(this->body) == 0
      && goldBodyResponse.httpResponse == this->httpResponse;
  }
};

#endif  // GOLDBODYRESPONSE_HPP
