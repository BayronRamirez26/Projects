/// Copyright 2022
/// @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
/// @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
/// @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
/// @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
///
/// Universidad de Costa Rica. CC BY 4.0

#ifndef GOLDBACH_HPP
#define GOLDBACH_HPP

#define MAX_RANGE (uint64_t)pow(2, 63)-1   // Create MAX RANGE := 2^63-1

#include <cstdlib>
#include <vector>
#include <string>
#include <iostream>

#include "GoldbachNumber.hpp"

/**
 * @brief Goldbach calculator class
 * @details This class is in charge of calculate the goldbach sums.
 */
class Goldbach {
 private:
  /// Stored the goldbach sums
  std::vector<GoldbachNumber> outputs;
  /// Stored the numbers entered by the user.
  std::vector<int64_t> inputs;
  /// Stored the primes numbers.
  std::vector<int64_t> primes;
  /// Is prime array
  std::vector<bool> isPrimeArray;
  /// Total calculated sums during the program.
  int64_t globalTotalSums;
  /// @brief Copies the numbers of the inputs to the attributes' input array
  /// @param inputs the inputs vector to copy
  void copyInputs(std::vector<int64_t>& inputs);
  /// @brief Calculates the total amount of sums for a number
  /// @param integer the number to calculates its' sums
  /// @param index index of the integer in the inputs array
  void calculate_total_of_sums(int64_t integer, int64_t index);
  /// @brief Calculates the total amount of sums for an even number
  /// @param integer the number to calculates its' sums
  /// @param index index of the integer in the inputs array
  void even_calculate_total_sums(int64_t integer, int64_t index);
  /// @brief Calculates the total amount of sums for an odd number
  /// @param integer the number to calculates its' sums
  /// @param index index of the integer in the inputs array
  void odd_calculate_total_sums(int64_t integer, int64_t index);
  /// @brief Calculates sums for a number
  /// @param integer the number to calculates its' sums
  /// @param index index of the integer in the inputs array
  void calculate_sums(int64_t integer,  int64_t index);
  /// @brief Calculates sums for an even number
  /// @param integer the number to calculates its' sums
  /// @param index index of the integer in the inputs array
  void even_calculate_sums(int64_t integer, int64_t index);
  /// @brief Calculates sums for an odd number
  /// @param integer the number to calculates its' sums
  /// @param index index of the integer in the inputs array
  void odd_calculate_sums(int64_t integer, int64_t index);
  /// @brief Determines if the number is prime
  /// @param number number
  /// @return boolean that ndicates if number is prime
  bool isPrime(int64_t number);

 public:
  /// @brief Goldbach constructor method.
  Goldbach();
  /// @brief Goldbach destructor method.
  ~Goldbach();
  /// @brief  Reads the array values and performs the calculations.
  /// @param inputs contains the numbers entered by the user.
  /// @return Returns the outputs array.
  std::vector<GoldbachNumber>& run(std::vector<int64_t>& inputs);
  /// @brief Reads the number and performs the calculations.
  /// @param number the number to do the sums.
  /// @return Returns the outputs array.
  std::vector<GoldbachNumber>* run(int64_t number);
  /// @brief Calculate primes numbers.
  /// @details This method is responsible for calculating the prime numbers.
  /// Search the prime numbers of the given number.
  /// @param biggestNumber stores the number to find the primes.
  void calculatePrimes(int64_t biggestNumber);
  /// @brief Process the inputs given by the user.
  /// @details This method is responsible for process the inputs given by the
  /// user and stores the result in "outputs".
  void processInputs();
  /// @brief Get a string with the total calculated sums during the program
  /// @return std::string the string containing the total calculated sums during
  /// the program
  std::string get_global_total_sums();
  /// @brief Get an invalid output string
  /// @param index the index of the invalid input
  /// @return std::string the string containing a message of the invalid output
  std::string get_invalid_output_string(int64_t index);
  /// @brief Get a string with the total of sums for a number
  /// @param index the index of the invalid input
  /// @return std::string the string containing the total of sums
  std::string get_total_of_sums_string(int64_t index);
  /// @brief Get a string with the sums
  /// @param index the index of the sums
  /// @return std::string the string containing a message of the sums
  std::string get_sums_string(int64_t index);
  /// @brief Get a string with the sums for an even number
  /// @param index the index of the even sums
  /// @return std::string the string containing a message of the even sums
  std::string get_even_sums_string(int64_t index);
  /// @brief Get a string with the sums for an odd number
  /// @param index the index of the odd sums
  /// @return std::string the string containing a message of the odd sums
  std::string get_odd_sums_string(int64_t index);
  /// @brief Get the outputs vector
  /// @return std::vector<GoldbachNumber>& the outputs vector
  std::vector<GoldbachNumber>& getOutputs();
  /// @brief Get the inputs vector
  /// @return std::vector<int64_t>& the inputs vector
  std::vector<int64_t>& getInputs();
  /// @brief Get the primes vector
  /// @return std::vector<int64_t>& the primes vector
  std::vector<int64_t>& getPrimes();
  /// @brief Gets the first number output
  GoldbachNumber* get_number_sums();
};

#endif  // GOLDBACH_HPP
