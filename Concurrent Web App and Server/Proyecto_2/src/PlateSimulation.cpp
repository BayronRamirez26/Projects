/**
 * @copyright Copyright (c) 2022
 * @file PlateSimulation.cpp
 * @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
 * @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
 * @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
 * @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
 * @brief Simulation of concurrent heat
 * @version 0.1
 * @date 2022-11-13
 */
#include "PlateSimulation.hpp"
#include <algorithm>
#include <iostream>

SIMUL::PlateSimulation::PlateSimulation() { }

SIMUL::PlateSimulation::~PlateSimulation() {
  for (size_t index = 0; index < this->plate_data.size(); ++index) {
    delete this->plate_data[index];
  }
  delete this->mpi;
}

int SIMUL::PlateSimulation::run(int argc, char* argv[]) {
  this->mpi = new Mpi(argc, argv);
  int error = SUCCESS;
  // error := analize_arguments(argc, argv)
  // if (process_number == 0) then
  if (mpi->rank() == 0) {
    error = analize_arguments(argc, argv);
    // if (!error) then
    if (!error) {
      // if (relative_route != "") then
      if (this->relative_route.compare("") != 0) {
        try {
          // declare vector as dynamic array of array of string
          std::vector<std::vector<std::string>> vector;
          // read_job_file(vector)
          SIMUL::read_job_file(vector, this->relative_route, this->job_file);
          // fill_plates_data(vector)
          this->fill_plates_data(vector);
          mpi->broadcast(error);
          // send_input_plates()
          this->send_input_plates();
          // receive_output_plates()
          this->receive_output_plates();
          // write_report_file()
          SIMUL::write_report_file(this->plate_data, this->job_file
            , this->relative_route);
        } catch (MpiError& exception) {
          std::cerr << "Error: " << exception.what() << std::endl;
          error = DISTRIBUTED_ERROR;
        } catch (std::runtime_error& exception) {
          std::cerr << "Error: " << exception.what() << std::endl;
          error = STREAM_ERROR;
        }
      } else {  // else
        error = INVALID_FILE_ERROR;
      }  // end if
    }  // end if
  } else {
    mpi->broadcast(error);
    if (!error) {
      // declare my_positions as dynamic array of integers
      std::vector<int64_t> my_positions;
      // receive_input_plates(my_positions)
      this->receive_input_plates(my_positions);
      // send_output_plates(my_positions)
      this->send_output_plates(my_positions);
    }
  }
  return error;
}

// procedure analize_arguments(argc, argv[]):
int SIMUL::PlateSimulation::analize_arguments(int argc, char* argv[]) {
  // declare error := SUCCESS
  int error = SUCCESS;
  // if (argc == 3) then
  if (argc == 3) {
    // if (find(argv[1], "job") == false) then
    std::string argument1 = argv[1];
    if (argument1.find("job") == std::string::npos) {
      // error := ARGUMENT_ERROR
      error = JOB_FILE_ERROR;
    } else {
      // job_file := argv[1]
      this->job_file = argv[1];
      // relative_route := argv[2]
      this->relative_route = argv[2];
    }  // end if
  } else {
    // if (argc >= 4) then
    if (argc >= 4) {
      std::string argument1 = argv[1];
      // if (find(argv[1], "job") == false) then
      if (argument1.find("job") == std::string::npos) {
        // error := ARGUMENT_ERROR
        error = JOB_FILE_ERROR;
      } else {
        // job_file := argv[1]
        this->job_file = argv[1];
        // thread_count := atoi(argv[2])
        this->thread_count = std::atoi(argv[2]);
        // relative_route := argv[3]
        this->relative_route = argv[3];
      }  // end if
    } else {
      // error := ARGUMENT_HELP_ERROR
      error = ARGUMENT_HELP_ERROR;
    }  // end if
  }
  return error;
}  // end analize_arguments

// procedure send_input_plates():
void SIMUL::PlateSimulation::send_input_plates() {
  // declare ready_process as integer := -1
  int64_t ready_process = -1;
  // declare stop_condition as boolean := false
  bool stop_condition = false;
  // declare thread_amount := 0
  int64_t thread_amount = 0;
  int64_t index = 0;
  // for index := 0 to count(plate_data) in steps of 1 do
  while (index < static_cast<int64_t>(plate_data.size())) {
    // receive(&ready_process, 1, from_process = any_process, tag = any_tag)
    this->mpi->receive(ready_process);
    // send(stop_condition, 1, ready_process, tag = any_tag)
    this->mpi->send(stop_condition, ready_process);
    // receive(&thread_amount, 1, ready_process, tag = any_tag)
    this->mpi->receive(thread_amount, ready_process);
    thread_amount = std::min(static_cast<int64_t>(plate_data.size() - index),
      thread_amount);
    this->mpi->send(thread_amount, ready_process);
    // for index2 := 0 to thread_amount in steps of 1 do
    for (int64_t index2 = 0; index2 < thread_amount; ++index2) {
      // send(index, 1, ready_process, tag = 0)
      this->mpi->send(index, ready_process);
      // send_plate_data(plate_data[index], ready_process)
      this->send_input_plate(plate_data[index], ready_process);
      ++index;
    }  // end for
  }  // end for
  // stop_condition := true
  stop_condition = true;
  // for index := 0 to process_count in steps of 1 do
  for (int64_t index = 1;
    index < static_cast<int64_t>(this->mpi->getProcessCount()); ++index) {
    // receive(&ready_process, 1, from_process = any_process, tag = any_tag)
    this->mpi->receive(ready_process);
    // send(stop_condition, 1, ready_process, tag = 0)
    this->mpi->send(stop_condition, ready_process);
  }  // end for
}  // end send_input_plates

// procedure send_input_plate(single_plate_data, ready_process):
void SIMUL::PlateSimulation::send_input_plate(plate_data_t* plate_data,
 int64_t ready_process) {
  // // Send necessary input data
  // send(single_plate_data.rows, 1, ready_process)
  this->mpi->send(plate_data->rows, ready_process);
  // send(single_plate_data.columns, 1, ready_process)
  this->mpi->send(plate_data->columns, ready_process);
  // send(single_plate_data.duration, 1, ready_process)
  this->mpi->send(plate_data->duration, ready_process);
  // send(single_plate_data.diffusivity, 1, ready_process)
  this->mpi->send(plate_data->diffusivity, ready_process);
  // send(single_plate_data.dimensions, 1, ready_process)
  this->mpi->send(plate_data->dimensions, ready_process);
  // send(single_plate_data.balance_point, 1, ready_process)
  this->mpi->send(plate_data->balance_point, ready_process);
  // Send matrix
  // for index1 := 0 to single_plate_data.rows in steps of 1 do
  for (int64_t index1 = 0; index1 < plate_data->rows; ++index1) {
    // for index2 := 0 to single_plate_data.columns in steps of 1 do
    for (int64_t index2 = 0; index2 < plate_data->columns; ++index2) {
      // send(single_plate_data.plate[index1][index2])
      this->mpi->send(plate_data->plate[index1][index2], ready_process);
    }  // end for
  }  // end for
}  // end send_input_plate

// procedure receive_output_plates():
void SIMUL::PlateSimulation::receive_output_plates() {
  // declare ready as boolean := true
  bool ready = true;
  // declare number_units as integer := -1
  int64_t number_units = -1;
  // for index := 1 to process_count in steps of 1 do
  for (int64_t index = 1
    ; index < static_cast<int64_t>(this->mpi->getProcessCount()); ++index) {
    // send(ready, 1, index, tag = any_tag)
    mpi->send(ready, index);
    // receive(&number_units, 1, index, tag = any_tag)
    mpi->receive(number_units, index);
    // for index2 := 0 to number_units in steps of 1 do
    for (int64_t index_2 = 0; index_2 < number_units; ++index_2) {
      // receive_output_plate(index)
      receive_output_plate(index);
    }  // end for
  }  // end for
}  // end receive_output_plates

// procedure receive_output_plate(from_process):
void SIMUL::PlateSimulation::receive_output_plate(int64_t from_process) {
  // declare index as integer := -1
  int64_t index = -1;
  // // Receive necessary output data
  // receive(&index, 1, from_process, tag = any_tag)
  mpi->receive(index, from_process);
  // receive(&plate_data[index].states, 1, from_process, tag = any_tag)
  mpi->receive(this->plate_data[index]->states, from_process);
  // receive(&plate_data[index].time_passed, 1, from_process, tag = any_tag)
  mpi->receive(this->plate_data[index]->time_passed, from_process);
  // for index1 := 0 to plate_data[index].rows in steps of 1 do
  for (int64_t index_1 = 0; index_1 < plate_data[index]->rows; ++index_1) {
    // for index2 := 0 to plate_data[index].columns in steps of 1 do
    for (int64_t index_2 = 0; index_2 < plate_data[index]->columns; ++index_2) {
      // receive(&plate_data[index].plate[index1][index2], 1
        // , from_process, tag = any_tag)
      mpi->receive(this->plate_data[index]->plate[index_1][index_2]
        , from_process);
    }  // end for
  }  // end for
}  // end receive_output_plate

// procedure receive_input_plates(my_positions):
void SIMUL::PlateSimulation::receive_input_plates(
  std::vector<int64_t>& my_positions) {
  // declare counter as integer := 0
  int64_t counter = 0;
  // declare thread_amount as integer :=  MAX_CPUS
  int64_t thread_amount = omp_get_max_threads();
  int64_t unit_count = 0;
  // while true do
  while (true) {
    // declare ready_process as integer := process_number
    int64_t ready_process = this->mpi->rank();
    // declare stop_condition as boolean := false
    bool stop_condition = false;
    // send(ready_process, 1, 0, tag = any_tag)
    this->mpi->send(ready_process, 0);
    // receive(&stop_condition, 1, 0, tag = any_tag)
    this->mpi->receive(stop_condition, 0);
    // if stop_condition == true then
    if (stop_condition) {
      // break
      break;
    }  // end if
    // declare my_position as integer := -1
    int64_t my_position = -1;
    // send(&thread_amount, 1, 0, tag = any_tag)
    this->mpi->send(thread_amount, /*toProcess*/ 0);
    this->mpi->receive(unit_count, 0);
    thread_amount = std::min(unit_count, thread_amount);
    std::cout << "My thread amount: " << thread_amount << std::endl;
    // for index := 0 to thread_amount in steps of 1 do
    for (int64_t index = 0; index < thread_amount; ++index) {
      // receive(&my_position, 1, 0, tag = any_tag)
      this->mpi->receive(my_position, 0);
      // append(my_positions, my_position)
      my_positions.push_back(my_position);
      // append(plate_data, new plate_data_t)
      this->plate_data.emplace_back(new plate_data_t());
      // receive_plate_data(plate_data[counter])
      this->receive_input_plate(plate_data[counter]);
      // counter := counter + 1
      ++counter;
    }  // end for
    #pragma omp parallel for num_threads(this->thread_count) schedule(dynamic) \
      default(none) shared(counter, thread_amount)
    // for index := (counter - thread_amount) to counter in steps of 1 do
    for (int64_t index = (counter - thread_amount); index < counter; ++index) {
      // work_plate(plate_data[index])
      this->work_plate(plate_data[index]);
    }  // end for
  }  // end while
}  // end procedure

// procedure receive_input_plate(plate_data):
void SIMUL::PlateSimulation::receive_input_plate(plate_data_t* plate_data) {
  // Receive necessary input data
  // receive(&plate_data.rows, 1, 0, tag = any_tag)
  this->mpi->receive(plate_data->rows, 0);
  // receive(&plate_data.columns, 1, 0, tag = any_tag)
  this->mpi->receive(plate_data->columns, 0);
  // receive(&plate_data.duration, 1, 0, tag = any_tag)
  this->mpi->receive(plate_data->duration, 0);
  // receive(&plate_data.diffusivity, 1, 0, tag = any_tag)
  this->mpi->receive(plate_data->diffusivity, 0);
  // receive(&plate_data.dimensions, 1, 0, tag = any_tag)
  this->mpi->receive(plate_data->dimensions, 0);
  // receive(&plate_data.balance_point, 1, 0, tag = any_tag)
  this->mpi->receive(plate_data->balance_point, 0);
  // Receive matrix
  // resize(plate_data.plate, plate_data.rows)
  plate_data->plate.resize(plate_data->rows);
  // for index1 := 0 to plate_data.rows in steps of 1 do
  for (int64_t index1 = 0; index1 < plate_data->rows; ++index1) {
    // resize(plate_data.plate[index1], plate_data.columns)
    plate_data->plate[index1].resize(plate_data->columns);
    // for index2 := 0 to single_plate_data.columns in steps of 1 do
    for (int64_t index2 = 0; index2 < plate_data->columns; ++index2) {
      // receive(plate_data.plate[index1][index2])
      this->mpi->receive(plate_data->plate[index1][index2], 0);
    }  // end for
  }  // end for
}  // end procedure

// procedure send_output_plates(my_positions):
void SIMUL::PlateSimulation::send_output_plates(
    std::vector<int64_t> my_positions) {
  // declare ready as a boolean := false
  bool ready = false;
  // declare number_units := count(plate_data)
  int64_t number_units = this->plate_data.size();
  // receive(&ready, 1 , 0 , tag = any_tag)
  this->mpi->receive(ready, 0);
  // send(number_units, 1, 0, tag = any_tag)
  this->mpi->send(number_units, 0);
  // for index := 0 to number_units in steps of 1 do
  for (int64_t index = 0; index < number_units; ++index) {
    // send_output_plate(index, my_positions)
    send_output_plate(index, my_positions);
  }  // end for
}  // end procedure

// procedure send_output_plate(index, my_positions):
void SIMUL::PlateSimulation::send_output_plate(int64_t index
  , std::vector<int64_t> my_positions) {
  // send(my_positions[index], 1, 0, tag = any_tag)
  this->mpi->send(my_positions[index], 0);
  // send(plate_data[index].states, 1, 0 , tag = any_tag)
  this->mpi->send(this->plate_data[index]->states, 0);
  // send(plate_data[index].time_passed, 1, 0 , tag = any_tag)
  this->mpi->send(this->plate_data[index]->time_passed, 0);
  // // send(index, 1, 0 ,tag = any_tag) // Ojo: Prueba
  // this->mpi->send(index, 0);
  // for index1 := 0 to plate_data[index].rows in steps of 1 do
  for (int64_t index1 = 0; index1 < this->plate_data[index]->rows; ++index1) {
    // for index2 := 0 to plate_data[index].columns in steps of 1 do
    for (int64_t index2 = 0; index2 < plate_data[index]->columns; ++index2) {
      // send(plate_data[index].plate[index1][index2], 1 , 0, tag = any_tag)
      this->mpi->send(plate_data[index]->plate[index1][index2], 0);
    }  // end for
  }  // end for
}  // end procedure

// procedure fill_plates_data(vector[]):
void SIMUL::PlateSimulation::
  fill_plates_data(std::vector<std::vector<std::string>>& vector) {
  this->plate_data.resize(vector.size());
  // for index := 0 to vector size in steps of 1 do
  for (size_t index = 0; index < vector.size(); ++index) {
    this->plate_data[index] = new plate_data_t();
    // plate_data[index].file := vector[index].array[0];
    this->plate_data[index]->file = vector[index][0];
    // plate_data[index].duration := atoi(vector[index].array[1])
    this->plate_data[index]->duration = std::stoll(vector[index][1]);
    // plate_data[index].diffusivity := stod(vector[index].array[2])
    this->plate_data[index]->diffusivity = std::stod(vector[index][2]);
    // plate_data[index].dimensions := atoi(vector[index].array[3])
    this->plate_data[index]->dimensions = std::stoll(vector[index][3]);
    // plate_data[index].balance_point := stod(vector[index].array[4])
    this->plate_data[index]->balance_point = std::stod(vector[index][4]);
    // read_plate(plate_data[index].file)
    SIMUL::read_plate(this->plate_data[index]->file, this->relative_route
      , this->plate_data[index]);
  }  // end for
}  // end procedure

// procedure work_plates():
void SIMUL::PlateSimulation::work_plates() {
  // for index := 0 to plate_data size in steps of 1 do
  for (size_t index = 0; index < plate_data.size(); ++index) {
    // work_plate(plate_data[index])
    work_plate(plate_data[index]);
  }  // end for
}  // end procedure

double SIMUL::PlateSimulation::calculate_new_temperature
  (plate_data_t* plate_data, double actual_temp, double up_temp,
  double  low_temp, double left_temp, double right_temp) {
  // declare new_temperature as integer := 0
  double new_temperature = 0;
  // if (h != 0) then
  if (plate_data->dimensions != 0) {
    // declare constant rate as float := (plate_data.duration *
    // plate_data.diffusivity) / plate_data.dimensions^2
    double rate
      = static_cast<double>(plate_data->duration * plate_data->diffusivity)
      / (plate_data->dimensions * plate_data->dimensions);
    // new_temperature := actual_temp + rate
    //   * (up_temp + low_temp + left_temp + right_temp - 4 * actual_temp)
    new_temperature = actual_temp + rate  *
     (up_temp + low_temp + left_temp + right_temp - 4 * actual_temp);
  }  // end if
  // return new_temperature
  return new_temperature;
}  // end function


// procedure work_plate(plate_data):
void SIMUL::PlateSimulation::work_plate(plate_data_t* plate_data) {
  // declare finish as boolean := false
  bool finish = false;
  std::vector<std::vector<double>> next_state_plate;
  // declare next_state_plate as array of inside_matrix_size of float
  next_state_plate.resize(plate_data->rows);
  for (int64_t index = 0; index < plate_data->rows; ++index)
    next_state_plate[index].resize(plate_data->columns);
  // while(!finish) do
  while (!finish) {
    // finish = do_next_state_plate(next_state_plate, plate_data, row_end
      // , col_end)
    finish = this->do_next_state_plate(next_state_plate, plate_data);
    // pass_next_state_plate(next_state_plate, plate_data)
    this->pass_next_state_plate(next_state_plate, plate_data);
    // plate_data.states := plate_data.states + 1
    plate_data->states = plate_data->states + 1;
    // plate_data.time_passed = plate_data.time_passed + plate_data.duration
    plate_data->time_passed = plate_data->time_passed + plate_data->duration;
  }  // end while
}  // end procedure

void SIMUL::PlateSimulation::pass_next_state_plate
(std::vector<std::vector<double>>& next_state_plate, plate_data_t* plate_data) {
  // for row := 1 to row_end in steps of 1 do
  for (int64_t row = 1; row < (plate_data->rows - 1); ++row) {
    // for column := 1 to col_end in steps of 1 do
    for (int64_t column = 1; column < (plate_data->columns - 1); ++column) {
      // plate_data.plate[row][column] := next_state_plate[next_state_index]
      plate_data->plate[row][column] = next_state_plate[row][column];
    }  // end for
  }  // end for
}  // end procedure

bool SIMUL::PlateSimulation::do_next_state_plate
  (std::vector<std::vector<double>>& next_state_plate
  , plate_data_t* plate_data) {
  // declare finish as boolean := true
  bool the_finish = true;
  // for row := 1 to row_end in steps of 1 do
  for (int64_t row = 1; row < (plate_data->rows - 1); ++row) {
    // for column := 1 to col_end in steps of 1 do
    for (int64_t col = 1; col < (plate_data->columns - 1); ++col) {
      // declare constant new_temperature :=
      const double new_temperature =
        // calculate_new_temperature(plate_data, plate_data.plate[row][column]
        calculate_new_temperature(plate_data, plate_data->plate[row][col]
          // , plate_data.plate[row-1][column], plate_data.plate[row+1][column]
          , plate_data->plate[row-1][col], plate_data->plate[row+1][col]
          // , plate_data.plate[row][column-1], plate_data.plate[row][column+1])
          , plate_data->plate[row][col-1], plate_data->plate[row][col+1]);
      // if (abs(plate_data.plate[row][column] - new_temperature)
        // > plate_data.balance_point) then
      if (fabs(new_temperature - plate_data->plate[row][col])
        > plate_data->balance_point) {
        // finish := false
        the_finish = false;
      }
      // append(next_state_plate, new_temperature)
      next_state_plate[row][col] = new_temperature;
    }
  }
  return the_finish;
}  // end do_next_state_plate
