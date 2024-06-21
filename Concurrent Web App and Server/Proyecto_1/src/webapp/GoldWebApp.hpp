// Copyright 2021 Jeisson Hidalgo-Cespedes. Universidad de Costa Rica. CC BY 4.0

#ifndef GOLDWEBAPP_HPP
#define GOLDWEBAPP_HPP

#include <vector>

#include "Assembler.hpp"
#include "Goldbach.hpp"
#include "GoldBodyCreator.hpp"
#include "GoldData.hpp"
#include "GoldPacker.hpp"
#include "GoldSender.hpp"
#include "GoldSolver.hpp"
#include "GoldUrlAnalizer.hpp"
#include "HttpApp.hpp"
#include "Log.hpp"
#include "Socket.hpp"

/**
 * @brief A web application that calculates goldbach sums
 */
class GoldWebApp : public HttpApp {
  /// Objects of this class cannot be copied
  DISABLE_COPY(GoldWebApp);

 protected:
  /// Goldbach web app url analizer
  GoldUrlAnalizer* urlAnalizer = nullptr;
  /// Solvers for goldbach sums
  std::vector<GoldSolver*> solvers;
  /// Packer for the goldbach sums
  GoldPacker* packer = nullptr;
  /// Body creator for the goldbach sums
  GoldBodyCreator* bodyCreator = nullptr;
  /// Sender for the goldbach sums
  GoldSender* sender = nullptr;

 public:
  /// Get access to the unique instance of GoldWebApp. Singleton design
  static GoldWebApp& getInstance();
  /// Called by the web server when the web server is started
  void start() override;
  /// Called when the web server stops, in order to allow the web application
  /// clean up and finish as well
  void stop() override;

 private:
  /// Constructor
  GoldWebApp();
  /// Destructor
  ~GoldWebApp();
};

#endif  // GOLDWEBAPP
