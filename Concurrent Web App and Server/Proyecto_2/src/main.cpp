/**
 * @copyright Copyright (c) 2022
 * @file main.cpp
 * @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
 * @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
 * @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
 * @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
 * @brief main
 * @version 0.1
 * @date 2022-11-13
 */
#include <unistd.h>
#include <time.h>

#include "PlateSimulation.hpp"

int main(int argc, char* argv[]) {
  SIMUL::PlateSimulation plateSimulation;
  // Measure execution time
  struct timespec start_time, finish_time;  // Start and finish times
  clock_gettime(CLOCK_MONOTONIC, &start_time);  // Start time

  int error = plateSimulation.run(argc, argv);

  clock_gettime(CLOCK_MONOTONIC, &finish_time);  // Finish time
  double elapsed_time = finish_time.tv_sec - start_time.tv_sec +
    (finish_time.tv_nsec - start_time.tv_nsec) * 1e-9;  // Elapsed time
  fprintf(stderr, "Execution time: %.9lfs\n", elapsed_time);
  switch (error) {
    case ARGUMENT_ERROR:
      std::cerr << "Error: Invalid arguments" << std::endl;
      break;
    case ARGUMENT_HELP_ERROR:
      std::cerr << plateSimulation.help << std::endl;
      break;
    case INVALID_FILE_ERROR:
      std::cerr << "Error: Invalid file" << std::endl;
      break;
    case JOB_FILE_ERROR:
      std::cerr << "Error: Job file required" << std::endl;
      break;
    default:
      break;
  }
  return error;
}
