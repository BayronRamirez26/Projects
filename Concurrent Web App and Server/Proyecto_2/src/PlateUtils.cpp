/**
 * @copyright Copyright (c) 2022
 * @file PlateUtils.cpp
 * @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
 * @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
 * @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
 * @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
 * @brief Simulation of concurrent heat
 * @version 0.1
 * @date 2022-11-13
 */
#include <cstring>
#include <iomanip>

#include <sstream>

#include "PlateUtils.hpp"

/**
 * @brief Writes an integer in binary
 * 
 * @param output output file
 * @param number integer
 */
void writeIntInBinary(std::ofstream& output, int64_t number) {
  output.write(reinterpret_cast<char const*>(&number), sizeof(number));
}

/**
 * @brief Writes an double in binary
 * 
 * @param output output file
 * @param number Double
 */
void writeDoubleInBinary(std::ofstream& output, double number) {
  output.write(reinterpret_cast<char const*>(&number), sizeof(number));
}

/**
 * @brief Reads an integer in binary
 * 
 * @param input Input file
 * @return int64_t value read
 */
int64_t readIntInBinary(std::ifstream& input) {
  int64_t integer;
  input.read(reinterpret_cast<char*>(&integer), sizeof(integer));
  return integer;
}

/**
 * @brief Reads a double in binary
 * 
 * @param input Input file
 * @return double value read
 */
double readDoubleInBinary(std::ifstream& input) {
  double doubleRead;
  input.read(reinterpret_cast<char*>(&doubleRead), sizeof(doubleRead));
  return doubleRead;
}

// procedure read_job_file(vector[], relative_route, job_file):
void SIMUL::read_job_file(std::vector<std::vector<std::string>>& file_data
  , std::string relative_route, std::string job_file) {
  // declare line := ""
  std::string line = "";
  const std::string direction = relative_route + "/" + job_file;
  std::ifstream input_file(direction);
  int index = 0;
  if (input_file.is_open()) {
    // while (!EOF(relative_route + "/" + job_file)) do
    while (getline(input_file, line)) {  // line := read_line(job_file)
      // declare array as array of 5 of string
      file_data.emplace_back(std::vector<std::string>());
      file_data[index].resize(5);
      if (line.find(" ") != std::string::npos) {
        split_line(line, file_data[index], " ");
      } else {
        split_line(line, file_data[index], "\t");
      }
      ++index;
    }  // end while
    input_file.close();
  } else {
    fail("Could not open job file");
  }
}  // end read_job_file

// procedure split_line(line, array[], delimiter):
void SIMUL::split_line(std::string line, std::vector<std::string>& array
    , const std::string delimiter) {
  // declare start := 0, theEnd, delimL = length(delimiter), counter := 0
  size_t start = 0, end, delimL = delimiter.length(), counter = 0;
  // declare token := ""
  std::string token = "";
  while ((end = line.find(delimiter, start)) != std::string::npos) {
    // token := substring(line, start, theEnd - start)
    token = line.substr(start, end - start);
    if (token.length() == 0) {
      ++start;
    } else {
      start = end + delimL;
      // append(array, token)
      array[counter] = token;
      ++counter;
    }
  }
  // append(array, substring(line, start))
  array[counter] =(line.substr(start));
}  // end split_line

// procedure read_plate(plate_file):
void SIMUL::read_plate(std::string plate_file, std::string relative_route,
 plate_data_t* plate_data) {
  std::string line;
  const std::string direction = relative_route + "/" + plate_file;
  std::ifstream input_file(direction, std::ios::binary);
  if (input_file.is_open()) {
    // while (!EOF(relative_route + "/" + job_file)) do
    while (!input_file.eof()) {
      // plate_data.rows as integer := readInteger(plate_file)
      plate_data->rows = readIntInBinary(input_file);
      plate_data->plate.resize(plate_data->rows);
      // plate_data.columns as integer := readInteger(plate_file)
      plate_data->columns = readIntInBinary(input_file);
      // for row := 0 to rows in steps of 1 do
      for (int row = 0; row < plate_data->rows; ++row) {
        plate_data->plate[row].resize(plate_data->columns);
        // for column := 0 to columns in steps of 1 do
        for (int column = 0; column < plate_data->columns; ++column) {
          // plate_data.plate[row][column] := readFloat(plate_file)
          plate_data->plate[row][column] = readDoubleInBinary(input_file);
        }  // end for
      }  // end for
      input_file.peek();  // Verify it is not the end of the file
    }  // end while
    input_file.close();

  } else {
    fail("Could not open job file");
  }
}  // end read_plate

// procedure write_plate_report(plate_data):
void SIMUL::write_report_file(std::vector<plate_data_t*>& plate_data
  , std::string job_file, std::string relative_route) {
  // for index := 0 to plate_data size in steps of 1 do
  for (size_t index = 0; index < plate_data.size(); ++index) {
    // write_plate_report(plate_data[index])
    SIMUL::write_plate_report(plate_data[index], job_file, relative_route);
  }  // end for
}  // end write_report_file

// procedure write_plate_report(plate_data):
void SIMUL::write_plate_report(plate_data_t* plate_data
  , std::string job_file, std::string relative_route) {
  (void) relative_route;
  // declare constant file_number as string :=
    // substring(job_file, "job", ".txt")
  const std::string file_number
    = job_file.substr(job_file.find("job"), job_file.find(".txt"));
  const std::string folder_name
    = "output" + file_number.substr(file_number.find("0")) + "/";
  // Create folder
  system(std::string("mkdir -p outputs/" + folder_name).c_str());
  // declare constant output_file as string
    // := "output/job" + file_number + ".out"
  const std::string output_file = "outputs/" + folder_name + file_number
    + ".out";
  std::ofstream output(output_file, std::ios::app);
  if (output.is_open()) {
    // write_plate_state(plate_data)
    SIMUL::write_plate_state(plate_data, folder_name);
    // write_line(output_file, plate_data.file + "\t")
    output << std::string(plate_data->file + "\t");
    // write_line(output_file, plate_data.duration + "\t")
    output << std::string(std::to_string(plate_data->duration) + "\t");
    // write_line(output_file, plate_data.diffusivity + "\t")
    output
      << std::string(SIMUL::give_scientific_number(plate_data->diffusivity)
        + "\t");
    // write_line(output_file, plate_data.dimensions + "\t")
    output << std::string(std::to_string(plate_data->dimensions) + "\t");
    // write_line(output_file, plate_data.balance_point + "\t")
    output
      << std::string(SIMUL::give_scientific_number(plate_data->balance_point)
        + "\t");
    // write_line(output_file, plate_data.states + "\t")
    output << std::string(std::to_string(plate_data->states) + "\t");
    // write_line(output_file, form_date_string(plate_data.time_passed))
    output << std::string(SIMUL::form_date_string(plate_data->time_passed));
    output << std::endl;
    output.close();
  } else {
    fail("Could not open report file");
  }
}  // end write_plate_report

// procedure write_plate_state(plate_data):
void SIMUL::write_plate_state(plate_data_t* plate_data
  , std::string plate_folder) {
  // declare constant file_number as string :=
  //   substring(plate_data.file, "plate", ".bin")
  std::string file_number
    = plate_data->file.substr(plate_data->file.find("plate")
      , plate_data->file.find(".bin"));
  // Create folder
  system(std::string("mkdir -p outputs/" + plate_folder).c_str());
  // if (plate_data.states != 0)
  if (plate_data->states != 0) {
    // file_number := file_number + "-" + plate_data.states
    file_number = file_number + "-" + std::to_string(plate_data->states);
  }
  // declare constant output_file as string := "output/plate"
  // + file_number + ".bin"
  std::string output_file = "outputs/" + plate_folder + file_number + ".bin";
  std::ofstream output(output_file, std::ios::binary);
  if (output.is_open()) {
    // writeInteger(output_file, plate_file.rows)
    writeIntInBinary(output, plate_data->rows);
    // writeInteger(output_file, plate_file.columns)
    writeIntInBinary(output, plate_data->columns);
    // for row := 0 to rows in steps of 1 do
    for (int64_t row = 0; row < plate_data->rows; row++) {
      // for column := 0 to columns in steps of 1 do
      for (int64_t column = 0; column < plate_data->columns; column++) {
        // writeDouble(output_file, plate_data.plate[row][column])
        writeDoubleInBinary(output, plate_data->plate[row][column]);
      }  // end for
    }  // end for
    output.close();
  }
}  // end write_plate_state

// procedure form_date_string(time):
std::string SIMUL::form_date_string(int64_t time) {
  // declare constant number_of_seconds as integer := floor(time % 60)
  int64_t number_of_seconds = floor(time % 60);
  // declare constant number_of_minutes as integer := floor(time / 60) % 60
  int64_t number_of_minutes = static_cast<int64_t>(floor(time / 60)) % 60;
  // declare constant number_of_hours as integer := floor(time / 3600) % 24
  int64_t number_of_hours = static_cast<int64_t>(floor(time / 3600)) % 24;
  // declare constant number_of_days as integer := floor(time / 86400) % 30
  int64_t number_of_days =  static_cast<int64_t>(floor(time / 86400)) % 30;
  // declare constant number_of_months as integer := floor(time / 2.628e+6) % 12
  int64_t number_of_months = static_cast<int64_t>(floor(time / 2.628e+6)) % 12;
  // declare constant number_of_years as integer
    // := floor(time / 3.156e+7) % 9999
  int64_t number_of_years = static_cast<int64_t>(floor(time / 3.156e+7)) % 9999;
  // declare constant timeString as string :=
    // give_date_string(number_of_years, number_of_months, number_of_days)
      // + "\t"
    // + give_time_string(number_of_hours, number_of_minutes, number_of_seconds)
  std::string timeString = give_date_string(number_of_years, number_of_months,
    number_of_days) + "\t" + give_time_string(number_of_hours,
    number_of_minutes, number_of_seconds);
  // return timeString
  return timeString;
}  // end form_date_string


// procedure give_date_string(number_of_years, number_of_months,
// number_of_days):
std::string SIMUL::give_date_string(int64_t number_of_years,
  int64_t number_of_months, int64_t number_of_days) {
  // declare date as string := ""
  std::string date = "";
  // declare constant digits_in_years := log10(number_of_years) + 1
  int64_t digits_in_years = log10(number_of_years ? number_of_years : 1);
  // declare constant digits_in_months := log10(number_of_months) + 1
  int64_t digits_in_months = log10(number_of_months ? number_of_months : 1);
  // declare constant digits_in_days := log10(number_of_days) + 1
  int64_t digits_in_days = log10(number_of_days ? number_of_days : 1);

  // date := date + give_zeros_number(4-digits_in_years) + number_of_years + "/"
  date = date + give_zeros_number(4-digits_in_years) +
  std::to_string(number_of_years) + "/";
  // date := date + give_zeros_number(2-digits_in_months) +
  // number_of_months + "/"
  date = date + give_zeros_number(2-digits_in_months) +
    std::to_string(number_of_months) + "/";
  // date := date + give_zeros_number(2-digits_in_days) + number_of_days
  date = date + give_zeros_number(2-digits_in_days) +
    std::to_string(number_of_days);
  return date;
}  // end give_data_string

// procedure give_time_string(number_of_hours, number_of_minutes,
// number_of_seconds):
std::string SIMUL::give_time_string(int64_t number_of_hours
    , int64_t number_of_minutes, int64_t number_of_seconds) {
  // declare constant digits_in_hours := log10(number_of_hours) + 1
  int64_t digits_in_hours = log10(number_of_hours ?  number_of_hours :1);
  // declare constant digits_in_minutes := log10(number_of_minutes) + 1
  int64_t digits_in_minutes = log10(number_of_minutes ? number_of_minutes : 1);
  // declare constant digits_in_seconds := log10(number_of_seconds) + 1
  int64_t digits_in_seconds = log10(number_of_seconds ? number_of_seconds : 1);
  // declare date as string := ""
  std::string date = "";
  // date := date + give_zeros_number(2-digits_in_hours) + number_of_hours+ ":"
  date = date + give_zeros_number(2-digits_in_hours) +
    std::to_string(number_of_hours) + ":";
  // date := date + give_zeros_number(2-digits_in_minutes) +
    // number_of_minutes + ":"
  date = date + give_zeros_number(2-digits_in_minutes) +
    std::to_string(number_of_minutes) + ":";
  // date := date + give_zeros_number(2-digits_in_seconds) + number_of_seconds
  date = date + give_zeros_number(2-digits_in_seconds) +
    std::to_string(number_of_seconds);
  return date;
}  // end give_time_string

// procedure give_zeros_number(number_of_zeros):
std::string SIMUL::give_zeros_number(int64_t number_of_zeros) {
  // declare zeros_number as string := ""
  std::string zeros_number = "";
  // for index := 0 to number_of_zeros in steps of 1 do
  for (int64_t index = 0; index < (number_of_zeros - 1); ++index) {
    // zeros_number := zeros_number + "0"
    zeros_number = zeros_number + '0';
  }  // end for
  // return zeros_number
  return zeros_number;
}  // end give_zeros_number

std::string SIMUL::give_fixed_number(double number) {
  char buffer[20];
  snprintf(buffer, sizeof(buffer), "%.10f", number);
  int last_zero_found = std::strlen(buffer);
  for (int i = std::strlen(buffer) - 1; i >= 0; --i) {
    if (buffer[i] == '\0' || buffer[i] == '0' || buffer[i] == '.') {
      last_zero_found = i;
    } else {
      break;
    }
  }
  if (last_zero_found == 0) {
    last_zero_found++;
  }
  const int size = last_zero_found + 1;
  char fixed_number[size];
  std::strncpy(fixed_number, buffer, last_zero_found);
  fixed_number[last_zero_found] = '\0';
  return fixed_number;
}

std::string SIMUL::give_scientific_number(double number) {
  std::ostringstream stream;
  if (number <= 0.0001) {
    stream << std::setprecision(0) << std::scientific;
    stream << number;
    return stream.str();
  }
  return SIMUL::give_fixed_number(number);
}
