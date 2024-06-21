/// Copyright 2022
/// @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
/// @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
/// @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
/// @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
///
/// Universidad de Costa Rica. CC BY 4.0

#ifndef GOLDBODYCREATOR_HPP
#define GOLDBODYCREATOR_HPP

#include <string>
#include <vector>

#include "Assembler.hpp"
#include "GoldBodyResponse.hpp"
#include "GoldData.hpp"
#include "GoldUtils.hpp"
#include "Log.hpp"

/**
 * @brief Class GoldBodyCreator
 * @details Class in charge of creating a body response
 */
class GoldBodyCreator : public Assembler<GoldData, GoldBodyResponse> {
 protected:
  /// Handle HTTP requests. @see HttpServer::handleHttpRequest()
  /// @return true If this application handled the request, false otherwise
  /// Sends the homepage as HTTP response
  void serveHomepage(GoldBodyResponse& goldBodyResponse);
  /// Handle HTTP requests. @see HttpServer::handleHttpRequest()
  /// @return true If this application handled the request, false otherwise
  /// and another chained application should handle it
  void handleHttpRequest(GoldData& data, GoldBodyResponse& goldBodyResponse);
  /// Handle a HTTP request that starts with "/gold"
  /// @return true if the goldbach was handled, false if it must be
  /// handled by another application
  void serveGoldbach(GoldData& data, GoldBodyResponse& goldBodyResponse);
  /// Sends a page for a non found resouce in this server. This method is called
  /// if none of the registered web applications handled the request.
  /// If you want to override this method, create a web app, e.g NotFoundWebApp
  /// that reacts to all URIs, and chain it as the last web app
  void serveNotFound(GoldData& data, GoldBodyResponse& goldBodyResponse);
  /// @brief Generates an invalid response for the html body
  /// @return a string containg the html response body
  void generateInvalidHtmlBody(GoldBodyResponse& goldBodyResponse);
  /// @brief Generates the Hmtl responde body to show the numbers sums
  /// @return a string containg the html response body
  void generateHtmlBody(GoldData& data, GoldBodyResponse& goldBodyResponse);

 public:
  /// Constructor
  GoldBodyCreator();
  /// Destructor
  ~GoldBodyCreator();
  /// Consume the messages in its own execution thread
  int run() override;
  /// Override this method to process any data extracted from the queue
  void consume(GoldData data) override;
};

#endif  // GOLDBODYCREATOR_HPP
