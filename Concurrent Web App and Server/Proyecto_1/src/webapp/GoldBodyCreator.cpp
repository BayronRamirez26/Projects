/// Copyright 2022
/// @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
/// @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
/// @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
/// @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
///
/// Universidad de Costa Rica. CC BY 4.0

#include <iostream>

#include "GoldBodyCreator.hpp"
#include "HttpRequest.hpp"
#include "HttpResponse.hpp"

GoldBodyCreator::GoldBodyCreator() { }

GoldBodyCreator::~GoldBodyCreator() { }

int GoldBodyCreator::run() {
  // Start consuming
  this->consumeForever();
  // Push stop condition
  this->produce(GoldBodyResponse());
  // If the forever loop finished, no more messages will arrive
  // Print statistics
  return EXIT_SUCCESS;
}

void GoldBodyCreator::consume(GoldData data) {
  // Create body response
  GoldBodyResponse goldBodyResponse;
  goldBodyResponse.httpResponse = data.httpResponse;
  // Fill body response
  this->handleHttpRequest(data, goldBodyResponse);
  // Produce the body response
  this->produce(goldBodyResponse);
  delete data.outputs;
}

void GoldBodyCreator::handleHttpRequest(GoldData& data
  , GoldBodyResponse& goldBodyResponse) {
  if (data.serveNotFound) {  // Server not found
    goldBodyResponse.httpResponse->setStatusCode(404);
    goldBodyResponse.httpResponse->setHeader("Server", "AttoServer v1.0");
    goldBodyResponse.httpResponse->setHeader("Content-type"
      , "text/html; charset=ascii");
    this->serveNotFound(data, goldBodyResponse);
  } else {
    // Set HttpResponse metadata (headers)
    goldBodyResponse.httpResponse->setHeader("Server", "AttoServer v1.1");
    goldBodyResponse.httpResponse->setHeader("Content-type"
      , "text/html; charset=ascii");
    // If the home page was asked
    if (data.isHomePage) {
      this->serveHomepage(goldBodyResponse);
      data.isHomePage = false;
    } else {  // Serve Goldbach
      this->serveGoldbach(data, goldBodyResponse);
      if (data.validRequest) {
        delete data.inputs;
        for (size_t index = 0; index < data.outputs->size(); ++index)
          delete data.outputs->at(index);
      }
    }
  }
}
void GoldBodyCreator::serveHomepage(GoldBodyResponse& goldBodyResponse) {
  // Set HTTP response metadata (headers)
  // Build the body of the goldBodyResponse.body
  std::string title = "Goldbach sums";
  goldBodyResponse.body = "<!DOCTYPE html>\n"
    "<html lang=\"en\">\n"
    "  <meta charset=\"ascii\"/>\n"
    "  <title>" + title + "</title>\n"
    "  <style>body {font-family: monospace}</style>\n"
    "  <h1>" + title + "</h1>\n"
    "  <form method=\"get\" action=\"/gold\">\n"
    "    <label for=\"text\">Number</label>\n"
    "    <input type=\"text\" name=\"number\" required/>\n"
    "    <button type=\"submit\">Calculate</button>\n"
    "  </form>\n"
    "</html>\n";
}

void GoldBodyCreator::serveGoldbach(GoldData& data
  , GoldBodyResponse& goldBodyResponse) {
  // Set HTTP goldBodyResponse.body metadata (headers)
  if (data.validRequest) {  // Valid body to create
    // Build the body of the goldBodyResponse.body
    this->generateHtmlBody(data, goldBodyResponse);
  } else {  // If number was too big or inputed a letter
    // Build the body for an invalid request
    this->generateInvalidHtmlBody(goldBodyResponse);
  }
}

void GoldBodyCreator::
  generateInvalidHtmlBody(GoldBodyResponse& goldBodyResponse) {
  std::string title = "Invalid request";  // declare title := "Invalid request"
  goldBodyResponse.body =
    "<!DOCTYPE html>\n"
    "<html lang=\"en\">\n"
    "  <meta charset=\"ascii\"/>\n"
    "  <title>" + title + "</title>\n"
    "  <style>body {font-family: monospace} .err {color: red}</style>\n"
    "  <h1 class=\"err\">" + title + "</h1>\n"
    "  <p>Invalid request for goldbach sums</p>\n"
    "  <hr><p><a href=\"/\">Back</a></p>\n"
    "</html>\n";
}

void GoldBodyCreator::generateHtmlBody(GoldData& data
  , GoldBodyResponse& goldBodyResponse) {
  std::string title = "Goldbach Sums";  // declare title := "Goldbach Sums"
  // declare total := get_global_total_sums(goldbachCalculator)
  // Prints the amount of total sums
  for (size_t index = 0; index < data.outputs->size(); ++index) {
    data.global_total_sums += data.outputs->at(index)->totalSums;
  }
  std::string total = GUtil::get_global_total_sums(data.global_total_sums
    , data.outputs->size());
  goldBodyResponse.body =
    "<!DOCTYPE html>\n"
    "<html lang=\"en\">\n"
    "  <meta charset=\"ascii\"/>\n"
    "  <title>" + title + "</title>\n"
    "  <style>body {font-family: monospace} .err {color: red}</style>\n"
    "  <h1>" + title + "</h1>\n"
    "  <h2>" + total + "</h2>\n";
  for (size_t index = 0; index < data.outputs->size();
    ++index) {  // for index := 0 to outputs size do
    // if (getInputs(goldbachCalculator)[index] > 0) then
    if (data.inputs->at(index) > 0) {
      goldBodyResponse.body +=  "<p>"
        + GUtil::get_total_of_sums_string(data.inputs->at(index)
          , data.outputs->at(index)) + "</p>\n";
    } else {
      goldBodyResponse.body += "<p>"
        + GUtil::get_sums_string(data.inputs->at(index)
          , data.outputs->at(index)) + "</p>\n";
    }
  }
  goldBodyResponse.body +=
    "  <hr><p><a href=\"/\">Back</a></p>\n"
    "</html>\n";
}

void GoldBodyCreator::serveNotFound(GoldData& data
  , GoldBodyResponse& goldBodyResponse) {
  (void)data;
  // Build the body of the response
  std::string title = "Not found";
  goldBodyResponse.body = "<!DOCTYPE html>\n"
    "<html lang=\"en\">\n"
    "  <meta charset=\"ascii\"/>\n"
    "  <title>" + title + "</title>\n"
    "  <style>body {font-family: monospace} h1 {color: red}</style>\n"
    "  <h1>" + title + "</h1>\n"
    "  <p>The requested resouce was not found on this server.</p>\n"
    "  <hr><p><a href=\"/\">Homepage</a></p>\n"
    "</html>\n";
}
