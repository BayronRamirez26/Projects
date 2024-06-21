/*
 * Copyright 2022 Enrique Vilchez <enrique.vilchezlizano@ucr.ac.cr> CC-BY 4.0
 */

#ifndef MPI_ERROR_HPP
#define MPI_ERROR_HPP

#include <stdexcept>  // Header in c++ for exceptions
#include <cstring>
#include <string>


class Mpi;  // Forward declaration of Mpi class

/**
 * @brief Class MpiError
 * @details Wrapper for runtime exceptions for Mpi. Inherits from
 * std::runtime_error
 * 
 */
class MpiError : public std::runtime_error {
 public:
  /**
   * @brief Construct a new Mpi Error
   * @details Final exception message should be:
   *   - message
   * 
   * @param message message for the exception
   */
  explicit MpiError(const std::string& message);
  /**
   * @brief Construct a new Mpi Error
   * @details Final exception message should be:
   *   - hostname:process_number: message
   * 
   * @param message message for the exception
   * @param mpi Mpi object
   */
  MpiError(const std::string& message, const Mpi& mpi);
  /**
   * @brief Construct a new Mpi Error
   * @details Final exception message should be:
   *   - hostname:process_number.thread_number: message
   * 
   * @param message message for the exception
   * @param mpi Mpi object
   * @param threadNumber thread number in the process
   */
  MpiError(const std::string& message, const Mpi& mpi, const int threadNumber);
};

#endif  // MPI_ERROR_HPP

