/// Copyright 2022
/// @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
/// @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
/// @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
/// @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
///
/// Universidad de Costa Rica. CC BY 4.0

#ifndef GOLDBACH_SUMS_HPP
#define GOLDBACH_SUMS_HPP

#include <inttypes.h>
#include <stdint.h>
#include <vector>

/**
 * @brief Storage the values of the sums
 */
struct tripleNumber {
  int64_t value1;  /// First digit of the goldbach sum
  int64_t value2;  /// Second digit of the goldbach sum
  int64_t value3;  /// Third digit of the goldbach sum
  /// @brief Constructor with a set of values ​​per parameter
  /// @param value1 Value to insert in the first digit
  /// @param value2 Value to insert in the second digit
  /// @param value3 Value to insert in the third digit
  tripleNumber(int64_t value1, int64_t value2, int64_t value3) {
    this->value1 = value1;
    this->value2 = value2;
    this->value3 = value3;
  }
  /// @brief Constructor that sets to 0
  tripleNumber() {
    this->value1 = 0;
    this->value2 = 0;
    this->value3 = 0;
  }
  /// @brief Default destructor
  ~tripleNumber() {
  }
};

/**
 * @brief Goldbach number storer for the total amount of sums and the sums
 */
struct GoldbachNumber {
  int64_t totalSums;  // total amount of sums
  std::vector<tripleNumber> goldbachSums;  /// goldbach sum storer
 public:
  /// @brief Default constructor
  GoldbachNumber() {
    totalSums = 0;
  }
  GoldbachNumber(int64_t total_number, std::vector<tripleNumber>sums) {
    for (size_t index  = 0; index < sums.size(); ++index) {
      this->goldbachSums.emplace_back(sums[index].value1
        , sums[index].value2, sums[index].value3);
    }
    this->totalSums = total_number;
  }
  /// @brief Default destructor
  ~GoldbachNumber() {
  }
};

#endif  // GOLDBACH_SUMS_HPP
