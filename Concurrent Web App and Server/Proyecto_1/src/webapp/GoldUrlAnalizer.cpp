/// Copyright 2022
/// @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
/// @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
/// @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
/// @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
///
/// Universidad de Costa Rica. CC BY 4.0
#include <iostream>
#include "GoldUrlAnalizer.hpp"

GoldUrlAnalizer::GoldUrlAnalizer() { }

GoldUrlAnalizer::~GoldUrlAnalizer()  { }

int GoldUrlAnalizer::run() {
  // Start consuming
  this->consumeForever();
  // Push stop condition
  for (unsigned int index = 0; index < std::thread::hardware_concurrency()
    ; ++index)
    this->produce(GoldData());
  // If the forever loop finished, no more messages will arrive
  // Print statistics
  return EXIT_SUCCESS;
}

void GoldUrlAnalizer::consume(HttpSocketData data) {
  GoldData goldData;
  goldData.httpRequest = data.httpRequest;
  goldData.httpResponse = data.httpResponse;
  goldData.serveNotFound = data.serveNotFound;
  if (goldData.serveNotFound) {
    this->produce(goldData);
  } else {
    this->analizeUrl(data, goldData);
    if (goldData.isHomePage == true) {  // If it is homepage just enqueue
      this->produce(goldData);
    } else {  // Copy data for each number and enqueue
      GoldData goldDataSend;
      goldDataSend.httpRequest = goldData.httpRequest;
      goldDataSend.httpResponse = goldData.httpResponse;
      goldDataSend.inputs = goldData.inputs;
      goldDataSend.numberCount = goldData.numberCount;
      goldDataSend.validRequest = goldData.validRequest;
      if (goldDataSend.numberCount == 0) {
        this->produce(goldDataSend);
      } else {
        for (size_t index = 0; index < goldDataSend.numberCount; ++index) {
          goldDataSend.number = goldDataSend.inputs->at(index);
          goldDataSend.priority = index;
          this->produce(goldDataSend);
        }
      }
    }
  }
}

void GoldUrlAnalizer::analizeUrl(HttpSocketData& data, GoldData& goldData) {
  // TODO(you): OJO
  if (data.httpRequest->getMethod().compare("GET") == 0
    && data.httpRequest->getURI().compare("/") == 0) {  // Homepage requested
    goldData.isHomePage = true;
  } else {
    std::smatch matches;  // Regex input matches
    // lock(regexMutex)
    std::regex
    inQuery("^/gold([/]|\\?number=)((-?\\d+)$|(-?\\d+)(([%2C]|[,])-?\\d+)+)$");
    bool validRequest = std::regex_search(data.httpRequest->getURI(), matches
      , inQuery);
    // unlock(regexMutex)
    if (validRequest) {
      assert(matches.length() >= 3);
      std::vector<int64_t> inputs;  // declare inputs[]
      parseMatches(inputs, matches);  // parseMatches(inputs, matches)
      if (inputs.size() == 0) {  // If number was too big
        goldData.validRequest = false;
      } else {
        // Fill data
        goldData.inputs = new std::vector<int64_t>(inputs);
        goldData.numberCount = inputs.size();
      }
    } else {
      // Build the body for an invalid request
      goldData.validRequest = false;
    }
  }
}

std::vector<std::string>& GoldUrlAnalizer::split(std::vector<std::string>&
  answers, std::string string, std::string delimiter) {
  // declare start := 0, theEnd, delimL = length(delimiter)
  size_t start = 0, end, delimL = delimiter.length();
  // declare token := ""
  std::string token;

  while ((end = string.find(delimiter, start)) != std::string::npos) {
    // token := substring(string, start, theEnd - start)
    token = string.substr(start, end - start);
    start = end + delimL;
    // append(answers, token)
    answers.push_back(token);
  }
  // append(answers, substring(string, start))
  answers.push_back(string.substr(start));
  return answers;
}


void GoldUrlAnalizer::parseMatches(std::vector<int64_t>& results
, std::smatch& matches) {
  // declare stringsRead[]
  std::vector<std::string> stringsRead;  // String numbers from regex
  // if (find(",") in matches[2] == 1) then
  if (matches.str(2).find(",") != std::string::npos) {  // Found a coma
    // Splits numbers from string with ","
    this->split(stringsRead, matches.str(2), ",");
  } else {
    // Splits numbers from string with "%2C"
    this->split(stringsRead, matches.str(2), "%2C");
  }
  // for index := 0 to stringsRead size do
  for (size_t index = 0; index < stringsRead.size(); ++index) {
    try {
      // append(results, int(stringsRead[index]))
      results.push_back(std::stoll(stringsRead[index]));  // Convert strings
    }
    catch(const std::exception& e) {  // Number was too big. Send it as invalid
      results.clear();
      results.resize(0);
      std::cerr << e.what() << '\n';
    }
  }
}
