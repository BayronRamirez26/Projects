#include "TestingProgram.hpp"
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
/**
 * @brief 
 * 
 * @param file1 
 * @param file2 
 * @param epsilon 
 * @return true 
 * @return false 
 */
short TEST::compare_binary_plates(const std::string& file1
  , const std::string& file2, double epsilon) {
  std::ifstream input_file1(file1, std::ios::binary);
  std::ifstream input_file2(file2, std::ios::binary);
  if (input_file1.is_open() && input_file2.is_open() ) {
    while (!input_file1.eof() && (!input_file2.eof())) {
      const int rows1 = readIntInBinary(input_file1);
      const int cols1 = readIntInBinary(input_file1);
      const int rows2 = readIntInBinary(input_file2);
      const int cols2 = readIntInBinary(input_file2);
      if (rows1 == rows2 && cols1 == cols2) {
        for (int row = 0; row < rows1; ++row) {
          for (int column = 0; column < cols1; ++column) {
            double file1Cell = readDoubleInBinary(input_file1);
            double file2Cell = readDoubleInBinary(input_file2);
            if (fabs(file1Cell - file2Cell) > epsilon) {
              // Files are different
              return 0;  // Content is different
            }
          }  // end for
        }
      } else {
        // Files are different
        return -1;  // Lenght is different
      }
      input_file1.peek();
      input_file2.peek();
    }  // end while
    input_file1.close();
    input_file2.close();
  } else {
    throw std::runtime_error("Could not open test files");
  }
  return 1;
}