/// Copyright 2022
/// @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
/// @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
/// @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
/// @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
///
/// Universidad de Costa Rica. CC BY 4.0

#ifndef GOLDUTILS_HPP
#define GOLDUTILS_HPP

#define MAX_RANGE (uint64_t)pow(2, 63)-1   // Create MAX RANGE := 2^63-1

#include <math.h>
#include <vector>
#include <string>

#include "GoldbachNumber.hpp"

/// @brief Namespace containing utility functions for goldbach web app
namespace GUtil {

  /**
   * @brief Get an invalid output string
   * @param input input number
   * @return std::string contains the searched string
   */
  std::string get_invalid_output_string(int64_t input);

  /**
   * @brief Get the global total sums object
   * @param globalTotalSums stores the total amount of sums
   * @param sizeInput size of the vector of inputs
   * @return std::string contains the searched string
   */
  std::string get_global_total_sums(int64_t globalTotalSums, int64_t sizeInput);
  /**
   * @brief Get the total of sums string
   * @param input input number
   * @param output output with the sums
   * @return std::string contains the searched string
   */
  std::string get_total_of_sums_string(int64_t input, GoldbachNumber* output);

  /**
   * @brief Get the sums string
   * @param input input number
   * @param output output with the sums
   * @return std::string contains the searched string
   */
  std::string get_sums_string(int64_t input, GoldbachNumber* output);

  /**
   * @brief Get the even sums string
   * @param output output with the sums
   * @return std::string contains the searched string 
   */
  std::string get_even_sums_string(GoldbachNumber* output);

  /**
   * @brief Get the odd sums string
   * @param output output with the sums
   * @return std::string contains the searched string
   */
  std::string get_odd_sums_string(GoldbachNumber* output);
}  // namespace GUtil

#endif  // GOLDUTILS_HPP
