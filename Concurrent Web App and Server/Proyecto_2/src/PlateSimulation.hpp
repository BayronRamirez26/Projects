/**
 * @copyright Copyright (c) 2022
 * @file PlateSimulation.hpp
 * @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
 * @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
 * @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
 * @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
 * @brief Simulation of concurrent heat
 * @version 0.1
 * @date 2022-11-13
 */
#ifndef PLATE_SIMULATION_HPP
#define PLATE_SIMULATION_HPP

#include <omp.h>
#include <string>
#include <vector>

#include "Mpi_Wrapper/Mpi.hpp"
#include "PlateData.hpp"
#include "PlateUtils.hpp"
#include "TemperaturesErrors.hpp"

/**
 * @brief Namespace for concurrent heat simulation
 * 
 */
namespace SIMUL {
/**
 * @brief Class PlateSimulation
 * @details Class to simulate concurrent heat
 */
class PlateSimulation {
 protected:
  /*--------------------------------ATTRIBUTES------------------------------*/

  Mpi* mpi = nullptr;  /**< Mpi wrapper instance */
  // shared job_file as string := ""
  std::string job_file = "";  /**< Job file */
  // shared thread_count as integer := MAX_CPUS
  int64_t thread_count = omp_get_max_threads();  /**< Thread count */
  // shared relative_route as string := ""
  std::string relative_route = "";  /**< Relative route for files */
  // shared plate_data as dynamic array of plate_data_t
  std::vector<plate_data_t*> plate_data;  /**< Plate data array*/

  /*--------------------------------METHODS---------------------------------*/

  /**
   * @brief Analizes arguments of the program
   * 
   * @param argc argument count
   * @param argv argument vector
   * @return int error code @see TemperaturesErrors.hpp
   */
  int analize_arguments(int argc, char* argv[]);
  /**
   * @brief Fills plates data
   * 
   * @param vector vector containg arrays with a plates data
   */
  void fill_plates_data(std::vector<std::vector<std::string>>& vector);
  /**
   * @brief Works the simulation plates
   * 
   */
  void work_plates();
  /**
   * @brief Calculate to new temperature
   * 
   * @param plate_data plate data
   * @param actual_temp Actual temperature 
   * @param up_temp Up temperature
   * @param low_temp Low temperature
   * @param left_temp Left temperature
   * @param right_temp Right temperature
   * @return double new temperature
   */
  double calculate_new_temperature(plate_data_t* plate_data,
    double actual_temp, double up_temp, double  low_temp, double left_temp,
      double right_temp);

  /**
   * @brief Works a single plate
   * 
   * @param plate_data plate data
   */
  void work_plate(plate_data_t* plate_data);

  /**
   * @brief Passes the data to the next state
   * 
   * @param next_state_plate Next state to the plate
   * @param plate_data Plate data
   */
  void pass_next_state_plate(std::vector<std::vector<double>>& next_state_plate
    , plate_data_t* plate_data);

  /**
   * @brief Does the next state of a plate
   *
   * @param next_state_plate Next state to the plate
   * @param plate_data Plata data
   * @return bool indication of finish
   */
  bool do_next_state_plate(std::vector<std::vector<double>>& next_state_plate
    , plate_data_t* plate_data);

  /**
   * @brief Sends the input plates
   */
  void send_input_plates();

  /**
   * @brief Sends an input plate
   *
   * @param plate_data plate
   * @param ready_process process to which the plate will be send
   */
  void send_input_plate(plate_data_t* plate_data, int64_t ready_process);
  /**
   * @brief Sends the output plates
   *
   * @param my_positions vector of outputs original positions on outputs vector
   */
  void send_output_plates(std::vector<int64_t> my_positions);
  /**
   * @brief Sends an output plate
   *
   * @param index index of the local output to send
   * @param my_positions vector of outputs original positions on outputs vector
   */
  void send_output_plate(int64_t index, std::vector<int64_t> my_positions);
  /**
   * @brief Receive the input plates
   *
   * @param my_positions vector of outputs original positions on outputs vector
   */
  void receive_input_plates(std::vector<int64_t>& my_positions);
  /**
   * @brief Receive an input plate
   *
   * @param plate_data plate
   */
  void receive_input_plate(plate_data_t* plate_data);
  /**
   * @brief Receive the output plates
   */
  void receive_output_plates();
  /**
  * @brief Receive an output plate
  *
  * @param from_process form which process should be received
  */
  void receive_output_plate(int64_t from_process);

 public:
  /**
   * @brief Help constant for the program
   * 
   */
  const std::string help = "Usage:\n"
    "Option 1: JobFile RelativeRoute\n"
    "Option 2: JobFile ThreadCount RelativeRoute\n"
    "Please follow these parameter standards ans execute the program again\n";
  /**
   * @brief Construct a new Plate Simulation object
   * 
   */
  PlateSimulation();
  /**
   * @brief Destroy the Plate Simulation object
   * 
   */
  ~PlateSimulation();
  /**
   * @brief Run method to simulate concurrent heat
   * 
   * @param argc argument count
   * @param argv argument vector
   * @return int error code @see TemperaturesErrors.hpp
   */
  int run(int argc, char* argv[]);
};
}  // namespace SIMUL

#endif  // PLATE_SIMULATION_HPP
