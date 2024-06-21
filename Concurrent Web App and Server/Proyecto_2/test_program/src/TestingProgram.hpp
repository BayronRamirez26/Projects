/**
 * @file PlateSimulation.hpp
 * @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
 * @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
 * @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
 * @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
 * @brief testing program
 * @version 0.1
 * @date 2022-11-16
 * 
 * @copyright Copyright (c) 2022
 * 
 */
#ifndef TESTING_PROGRAM_HPP
#define TESTING_PROGRAM_HPP

#include <iostream>
#include <cinttypes>
#include <cmath>
#include <fstream>
#include <string>

/**
 * @brief Namespace for testing functions
 * 
 */
namespace TEST {
  /**
   * @brief Function to compare to binary files
   * @details Works for concurrent heat simulation outputs
   * 
   * @param file1 first file
   * @param file2 second file
   * @param epsilon sensitivity for comparisson of doubles
   * @return -1 if files lenght are different, 0 if files content is different
   * and 1 if they are equal
   */
  short compare_binary_plates(const std::string& file1, const std::string& file2
    , double epsilon);
};

#endif  // TESTING_PROGRAM_HPP
