// Copyright 2021 Jeisson Hidalgo-Cespedes. Universidad de Costa Rica. CC BY 4.0
// Serial web server's initial code for parallelization

#ifdef WEBSERVER

#include "HttpServer.hpp"
#include "GoldWebApp.hpp"

/// Start the web server
int main(int argc, char* argv[]) {
  // Register the web application(s) with the web server
  HttpServer::getInstance().chainWebApp(&GoldWebApp::getInstance());
  // Start the web server
  return HttpServer::getInstance().start(argc, argv);
}

#endif  // WEBSERVER
