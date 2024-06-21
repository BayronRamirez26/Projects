/**
 * @copyright Copyright (c) 2022
 * @file PlateUtils.hpp
 * @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
 * @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
 * @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
 * @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
 * @brief Simulation of concurrent heat
 * @version 0.1
 * @date 2022-11-13
 */
#ifndef PLATE_UTILS_HPP
#define PLATE_UTILS_HPP

#include <assert.h>
#include <cmath>
#include <fstream>
#include <iostream>
#include <string>
#include <stdexcept>
#include <vector>

#include "PlateData.hpp"
#include "TemperaturesErrors.hpp"

/**
 * @brief Namespace for concurrent heat simulation
 * 
 */
namespace SIMUL {
  /**
   * @brief Reads the job file content
   * @details Fills the file data vector with each of the job file lines
   * 
   * @param file_data file data vector of arrays of strings
   * @param relative_route relative route to file
   * @param job_file job file
   */
  void read_job_file(std::vector<std::vector<std::string>>& file_data,
    std::string relative_route, std::string job_file);
  /**
   * @brief Splits a line based on a delimiter
   * @details Modifies the array to contain each of the splitted strings
   * 
   * @param line line to split
   * @param array array to store the splits
   * @param delimiter delimited to do the splits
   */
  void split_line(std::string line, std::vector<std::string>& array
    , const std::string delimiter);

  /**
   * @brief Reads the plate matrix information
   * 
   * @param plate_file plate file
   * @param relative_route relative route to the plate file
   * @param plate_data plate data
   */
  void read_plate(std::string plate_file, std::string relative_route,
  plate_data_t* plate_data);

  /**
   * @brief Wirtes the report file
   * 
   * @param plate_data plates data vector
   * @param job_file job file
   * @param relative_route relative route to write the response
   */
  void write_report_file(std::vector<plate_data_t*>& plate_data
    , std::string job_file, std::string relative_route);

  /**
   * @brief Writes the plate report
   * 
   * @param plate_data plate data
   * @param job_file input job file
   * @param relative_route relative rout for the job file
   */
  void write_plate_report(plate_data_t* plate_data
    , std::string job_file, std::string relative_route);

  /**
   * @brief Writes the plate state
   * 
   * @param plate_data plate data
   * @param plate_folder plate file folder
   */
  void write_plate_state(plate_data_t* plate_data, std::string plate_folder);
  /**
   * @brief Forms a date string
   * 
   * @param time time elapsed
   * @return std::string date string
   */
  std::string form_date_string(int64_t time);
  /**
   * @brief Gives the date string
   * 
   * @param number_of_years number of yars
   * @param number_of_months number of months
   * @param number_of_days number of days
   * @return std::string date string
   */
  std::string give_date_string(int64_t number_of_years, int64_t number_of_months
    , int64_t number_of_days);
  /**
   * @brief Gives the time string
   * 
   * @param number_of_hours number of hours
   * @param number_of_minutes number of minutes
   * @param number_of_seconds number of seconds
   * @return std::string time string
   */
  std::string give_time_string(int64_t number_of_hours
    , int64_t number_of_minutes, int64_t number_of_seconds);
  /**
   * @brief Gives a string with as much zeros as requested
   * 
   * @param number_of_zeros number of zeros
   * @return std::string string with zeros
   */
  std::string give_zeros_number(int64_t number_of_zeros);
  /**
   * @brief Gives the fixed number with its exact number of decimals
   * 
   * @param number number
   * @return std::string string as the fixed number
   */
  std::string give_fixed_number(double number);
  /**
   * @brief Gives the scientific notation for a double number
   * 
   * @param number number
   * @return std::string string as the scientific number
   */
  std::string give_scientific_number(double number);
};  // namespace SIMUL

#endif  // PLATE_UTILS_HPPnt
