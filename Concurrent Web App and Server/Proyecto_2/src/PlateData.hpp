/**
 * @copyright Copyright (c) 2022
 * @file PlateData.hpp
 * @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
 * @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
 * @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
 * @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
 * @brief Structs containers
 * @version 0.1
 * @date 2022-11-13
 */
#ifndef PLATE_DATA_HPP
#define PLATE_DATA_HPP

#include <cinttypes>
#include <string>
#include <vector>

/**
 * @brief Plate data
 * @details A Plates's data
 * 
 */
struct plate_data_t {
  // plate as array of array of float,
  std::vector<std::vector<double>> plate;  /**< Plate matrix */
  // rows as integer,
  int64_t rows = 0;  /**< Plate matrix rows */
  // columns as integer,
  int64_t columns = 0;  /**< Plate matrix columns */
  // file as string,
  std::string file = "";  /**< File name */
  // duration as integer,
  int64_t duration = 0;  /**< Duration to get from one stage to other */
  // diffusivity as float,
  double diffusivity = 0.0;  /**< Thermic diffusivity */
  // dimensions as integer,
  int64_t dimensions = 0;  /**< Dimensions of a plate cell */
  // balance_point as float,
  double balance_point = 0.0;  /**< Balance point */
  // states as integer,
  int64_t states = 0;  /**< Plate states */
  // time_passed as integer,
  int64_t time_passed = 0; /**< Time elapsed between each interaction */
// end record
};

#endif  // PLATE_DATA_HPP
