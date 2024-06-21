/// Copyright 2022
/// @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
/// @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
/// @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
/// @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
///
/// Universidad de Costa Rica. CC BY 4.0

#include "GoldUtils.hpp"

// procedure get_invalid_output_string(index)
std::string GUtil::get_invalid_output_string(int64_t input) {
  // string invalidOutputString = ""
  std::string invalidOutputString = "";
  // Declare integer := this->inputs[index]
  int64_t integer = input;
  // if ((uint64_t)integer >= (MAX_RANGE)) then
  if ((uint64_t)integer >= (MAX_RANGE)) {  // Greater than the max range
    // invalidOutputString += integer
    invalidOutputString += std::to_string(integer);
    // invalidOutputString += ": NA\n"
    invalidOutputString += ": NA\n";
  } else {
    // invalidOutputString += integer
    invalidOutputString += std::to_string(integer);
    // invalidOutputString += ": NA\n"
    invalidOutputString += ": NA\n";
  }
  // return invalidOutputString
  return invalidOutputString;
// end procedure
}

// procedure string get_global_total_sums():
std::string GUtil::get_global_total_sums(int64_t globalTotalSums,
int64_t sizeInput) {
  // string globalTotalSumsString = ""
  std::string globalTotalSumsString = "";
  // globalTotalSumsString += "Total " + this->inputs.size()
  // + " numbers " + this->globalTotalSums + " sums"
  globalTotalSumsString += "Total " + std::to_string(sizeInput)
     + " numbers " + std::to_string(globalTotalSums) + " sums\n\n";
  // return globalTotalSumsString
  return globalTotalSumsString;
// end procedure
}


  // procedure get_total_of_sums_string(index)
  std::string GUtil::get_total_of_sums_string
    (int64_t input, GoldbachNumber* output) {
    // string totalSumsString = ""
    std::string totalSumsString = "";
    // Declare integer := this->inputs[index]
    int64_t integer = input;
    // if ((uint64_t)integer >= (MAX_RANGE) || integer <= 3 || integer == 5)
    if ((uint64_t)integer >= (MAX_RANGE) || integer <= 3 || integer == 5) {
      // totalSumsString += get_invalid_output_string(index)
      totalSumsString += get_invalid_output_string(input);
    } else {
      // totalSumsString += this->inputs[index] + ": "
      // + this->outputs[index].totalSums + " sums"
      totalSumsString +=  std::to_string(input) + ": "
      + std::to_string(output->totalSums) + " sums";
    }
    return totalSumsString;
  }

  // procedure get_sums_string(index)
  std::string GUtil::get_sums_string(int64_t input, GoldbachNumber* output) {
    std::string sumsString = "";
    // Declare integer := integer * -1
    int64_t integer = input * (-1);
    // if ((uint64_t)integer >= (MAX_RANGE) || integer <= 3 || integer == 5)
    if ((uint64_t)integer >= (MAX_RANGE) || integer <= 3 || integer == 5) {
      // sumsString += get_invalid_output_string(index)
      sumsString += get_invalid_output_string(integer);
    } else {
      // sumsString += this->inputs[index] + ": "
      // + this->outputs[index].totalSums + " sums: "
      sumsString += std::to_string(input) + ": "
        + std::to_string(output->totalSums) + " sums: ";
      // if (integer%2 == 0) then
      if (integer%2 == 0) {
        // sumsString += get_even_sums_string(index)
        sumsString += get_even_sums_string(output);
      } else {
        // sumsString += get_odd_sums_string(index)
        sumsString += get_odd_sums_string(output);
      }
    }
    // return sumsString
    return sumsString;
  // end procedure
  }

  // procedure get_even_sums_string(index)
  std::string GUtil::get_even_sums_string(GoldbachNumber* output) {
    // string sumsString = ""
    std::string sumsString = "";
    // Declare total_sums := this->outputs[index].goldbachSums.size()
    int64_t total_sums = output->goldbachSums.size();
    // for array_index := 0 to _total_sums do
    for (int64_t array_index=0; array_index < total_sums; array_index++) {
      // if (array_index == total_sums-1) then
      if (array_index == total_sums-1) {
          // sumsString += sums triple_elements[array_index]_value2 " + "
          sumsString += std::to_string(output->
            goldbachSums[array_index].value2) + " + ";
          // sumsString += sums triple_elements[array_index]_value3 " \n"
          sumsString += std::to_string(output->
            goldbachSums[array_index].value3) + "\n";
      } else {
        // sumsString += sums triple_elements[array_index]_value2 " + "
        sumsString += std::to_string(output->
            goldbachSums[array_index].value2) + " + ";
        // sumsString += sums triple_elements[array_index]_value3 ", "
        sumsString += std::to_string(output->
          goldbachSums[array_index].value3) + ", ";
      }
    // end for
    }
    // return sumsString
    return sumsString;
  // end procedure
  }

  // procedure get_odd_sums_string(int64_t index)
  std::string GUtil::get_odd_sums_string(GoldbachNumber* output) {
    // string sumsString = " "
    std::string sumsString = " ";
    // Declare total_sums := this->outputs[index].goldbachSums.size()
    int64_t total_sums = output->goldbachSums.size();
    // for array_index := 0 to total_sums do
    for (int64_t array_index = 0; array_index < total_sums; array_index++) {
      // if (array_index == total_sums-1) then
      if (array_index == total_sums-1) {
        // sumsString += sums triple_elements[array_index]_value1 " + "
        sumsString += std::to_string(output->
          goldbachSums[array_index].value1) + " + ";
        // sumsString += sums triple_elements[array_index]_value2 " + "
        sumsString += std::to_string(output->
          goldbachSums[array_index].value2) + " + ";
        // sumsString += sums triple_elements[array_index]_value3 "\n"
        sumsString += std::to_string(output->
          goldbachSums[array_index].value3) + "\n";
      // else
      } else {
        // sumsString += sums triple_elements[array_index]_value1 " + "
        sumsString += std::to_string(output->
          goldbachSums[array_index].value1) + " + ";
        // sumsString += sums triple_elements[array_index]_value2 " + "
        sumsString += std::to_string(output->
          goldbachSums[array_index].value2) + " + ";
        // sumsString += sums triple_elements[array_index]_value3 ","
        sumsString += std::to_string(output->
          goldbachSums[array_index].value3) + ", ";
      }
    // end for
    }
    // return sumsString
    return sumsString;
  // end procedure
  }
