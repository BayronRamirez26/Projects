// #ifdef TEST_PROGRAM

#include <iostream>
#include <stdexcept>
#include "TestingProgram.hpp"

int main(int argc, char* argv[]) {
  if (argc == 4) {
    try {
      std::string file1 = argv[1];
      std::string file2 = argv[2];
      double epsilon = std::stod(argv[3]);
      short state = TEST::compare_binary_plates(std::string("outputs/" + file1)
        , std::string("tests/" + file2), epsilon);
      if (state == -1) {
        std::cout << "Files' rows and columns are different" << std::endl;
      } else if (state == 0) {
        std::cout << "Files' content in cells is different" << std:: endl;
      } else {
        std::cout << "Files are the same" << std::endl;
      }
    } catch (const std::invalid_argument& exception) {
      std::cerr << "Error: Invalid epsilon value" << std::endl;
    } catch (const std::runtime_error& exception) {
      std::cerr << "Error: " << exception.what() << std::endl;
    }
    
  } else {
    std::cout << "Usage: file1 file2 epsilon" << std::endl;
  }
}
// #endif  // TEST_PROGRAM
