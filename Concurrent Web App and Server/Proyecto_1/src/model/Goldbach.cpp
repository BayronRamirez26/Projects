/// Copyright 2022
/// @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
/// @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
/// @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
/// @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
///
/// Universidad de Costa Rica. CC BY 4.0

#include <cmath>

#include "Goldbach.hpp"

///
/// @brief Storage the values of the sums
/// @param inputs set of numbers entered by the user
/// @return Returns the largest number in the array
////
// procedure int64_t calculateBiggest(vector<int64_t>& inputs):
int64_t calculateBiggest(std::vector<int64_t>& inputs) {
  // biggestNumber := 0
  int64_t biggestNumber = 0;
  // for  index = 0 index to inputs.size() do
  for (size_t index = 0; index < inputs.size(); index++) {
    // if (inputs[index] < 0) then
    if (inputs[index] < 0) {
      // if (inputs[index]*(-1) > biggestNumber) then
      if (inputs[index]*(-1) > biggestNumber) {
        // biggestNumber := inputs[index]*(-1)
        biggestNumber = inputs[index]*(-1);
      }
    // else
    } else {
      // if (inputs[index] > biggestNumber) then
      if (inputs[index] > biggestNumber) {
        // biggestNumber := inputs[index]
        biggestNumber = inputs[index];
      }
    }
  // end for
  }
  // return biggestNumber
  return biggestNumber;
// end procedure
}


Goldbach::Goldbach() {
  this->globalTotalSums = 0;
}

Goldbach::~Goldbach() {
}

void Goldbach::processInputs() {
  // Create value := 0
  int64_t value = 0;
  // amount_inputs := inputs_array count
  size_t amount_inputs = this->inputs.size();
  // for index := 0 to amount_inputs do
  for (size_t index=0; index < amount_inputs; index++) {
    // value := dynamic_array_calculate(inputs_array, index)
    value = this->inputs[index];
    if (value < 0) {
      // value := value*(-1)
      value = value*(-1);
      if ((value > 5 || value == 4) && (uint64_t)value < MAX_RANGE) {
        // calculate_sums(value, index)
        calculate_sums(value, index);
        // outputs_information[index]_total_sums :=
        // outputs_information[index]_goldbachSums count
        this->outputs[index].totalSums =
            this->outputs[index].goldbachSums.size();
        this->globalTotalSums += this->outputs[index].totalSums;
      }
    } else {
      if ((value > 5 || value == 4) && (uint64_t)value < MAX_RANGE) {
        // calculate_total_of_sums(value, index)
        calculate_total_of_sums(value, index);
        this->globalTotalSums += this->outputs[index].totalSums;
      }
    }
  }
}

// procedure vector<GoldbachNumber> run(vector<int64_t> inputs):
std::vector<GoldbachNumber>& Goldbach::run(std::vector<int64_t>& inputs) {
  // copyInputs(inputs)
  copyInputs(inputs);
  // calculatePrimes(calculateBiggest(inputs))
  calculatePrimes(calculateBiggest(inputs));
  // this->outputs.resize(inputs.size())
  this->outputs.resize(inputs.size());
  // processInputs()
  processInputs();
  // return (this->outputs)
  return (this->outputs);
// end procedure
}

// procedure vector<GoldbachNumber> run(vector<int64_t> inputs):
std::vector<GoldbachNumber>* Goldbach::run(int64_t number) {
  // Clean vectors
  this->inputs.clear();
  this->outputs.clear();
  this->primes.clear();
  // Push number to inputs
  this->inputs.push_back(number);
  // calculatePrimes(calculateBiggest(inputs))
  calculatePrimes(calculateBiggest(inputs));
  // this->outputs.resize(inputs.size())
  this->outputs.resize(inputs.size());
  // processInputs()
  processInputs();
  // return (this->outputs)
  return &this->outputs;
}

void Goldbach::calculatePrimes(int64_t biggestNumber) {
  this->isPrimeArray.resize(biggestNumber+1);
  for (size_t index = 0; index < isPrimeArray.size(); ++index) {
    isPrimeArray[index] = false;  // Clean array
  }
  isPrimeArray[2] = true;  // isPrimeArray[2] := true
  isPrimeArray[3] = true;  // isPrimeArray[3] := true
  isPrimeArray[5] = true;  // isPrimeArray[5] := true
  this->primes.push_back(2);  // append(primes, 2)
  this->primes.push_back(3);  // append(primes, 3)

  // declare factor := sqrt(biggest_number) + 1
  int64_t factor = (int64_t) sqrtl((long double) biggestNumber) + 1;
  // declare verif_number := 0
  int64_t verification_number = 0;
  for (int64_t x = 1; x <= factor; ++x) {  // for x := 1 to factor do
    for (int64_t y = 1; y <= factor; ++y) {  // for y := 1 to factor do
      // verif_number := 4 * x * x + y * y. Same as n = 4x^2 +y^2.
      verification_number = 4 * x * x + y * y;
      // verification_1 :=
      bool verification_1 =
      // mod(verif_number, 60) == 1 or mod(verif_number, 60) == 13 or
      verification_number % 60 == 1 || verification_number % 60 == 13 ||
      // mod(verif_number, 60) == 17 or mod(verif_number, 60) == 29 or
      verification_number % 60 == 17 || verification_number % 60 == 29 ||
      // mod(verif_number, 60) == 37 or mod(verif_number, 60) == 41 or
      verification_number % 60 == 37 || verification_number % 60 == 41 ||
      // mod(verif_number, 60) == 49 or mod(verif_number, 60) == 53
      verification_number % 60 == 49 || verification_number % 60 == 53;
      // if (verif_number <= biggestNumber and verification_1) then
      if (verification_number <= biggestNumber && verification_1) {
        // isPrimeArray[verif_number] = !isPrimeArray[verif_number]
        isPrimeArray[verification_number] =
          !isPrimeArray[verification_number];
      }
      // verif_number := 3 * x * x + y * y. Same as n = 3x^2 + y^2
      verification_number = 3 * x * x + y * y;
      // verification_2 :=
      bool verification_2 =
      // mod(verif_number, 60) == 7 or mod(verif_number, 60) == 19 or
      verification_number % 60 == 7 || verification_number % 60 == 19 ||
      // mod(verif_number, 60) == 31 or mod(verif_number, 60) == 43
      verification_number % 60 == 31 || verification_number % 60 == 43;
      // if (verif_number <= biggest_number and verification_2) then
      if (verification_number <= biggestNumber && verification_2) {
        // isPrimeArray[verif_number] = !isPrimeArray[verif_number]
        isPrimeArray[verification_number] =
          !isPrimeArray[verification_number];
      }
      // verif_number := 3 * x * x - y * y. Same as n = 3x^2 - y^2
      verification_number = 3 * x * x - y * y;
      // verification_3 :=
      bool verification_3 =
      // mod(verif_number, 60) == 11 or mod(verif_number, 60) == 23 or
      verification_number % 60 == 11 || verification_number % 60 == 23 ||
      // mod(verif_number, 60) == 47 or mod(verif_number, 60) == 59
      verification_number % 60 == 47 || verification_number % 60 == 59;
      // if x > y and verif_number <= biggestNumber and verification_3 then
      if (x > y && verification_number <= biggestNumber &&
          verification_3) {
        // isPrimeArray[verif_number] = !isPrimeArray[verif_number]
        isPrimeArray[verification_number] =
          !isPrimeArray[verification_number];
      }
    }  // end for
  }  // end for
  // for number1 := 5 to factor do
  for (int64_t number1 = 5; number1 <= factor; ++number1) {
    // if (isPrimeArray[number1] == 1) then
    if (isPrimeArray[number1] == true) {
      // for number2 := 1 until number2*number1*number1 <= biggestNumber do
      for (int64_t number2 = 1; number2*number1*number1 <= biggestNumber;
          ++number2) {
        // isPrimeArray[number2*number1*number1] = false
        isPrimeArray[number2*number1*number1] = false;
      }  // end for
    }  // end if
  }  // end for
  // for number := 5 to biggestNumber do
  for (int64_t number = 5; number < biggestNumber; ++number) {
    // if (isPrimeArray[number] == 1) then
    if (isPrimeArray[number] == true) {
      // primes.push_back(number)
      this->primes.push_back(number);
    }  // end if
  }  // end for
// end procedure
}


void Goldbach::copyInputs(std::vector<int64_t>& inputsReceive) {
  this->outputs.clear();
  this->inputs.clear();
  for (size_t index = 0; index < inputsReceive.size(); index++) {
    this->inputs.push_back(inputsReceive[index]);
  }
}

// procedure calculate_total_of_sums(integer, index)
void Goldbach::calculate_total_of_sums(int64_t integer, int64_t index) {
  if (integer %2 == 0) {
    // total_sums := even_calculate_total_sums(primes, integer)
    even_calculate_total_sums(integer, index);
  } else {
    // total_sums := odd_calculate_total_sums(primes, integer)
    odd_calculate_total_sums(integer, index);
  }
}

// procedure calculate_sums(primes, integer)
void Goldbach::calculate_sums(int64_t integer, int64_t index) {
  if (integer%2 == 0) {
    // sums_array := even_calculate_sums(primes, integer)
    even_calculate_sums(integer, index);
  } else {
    // sums_array := odd_calculate_sums(primes, integer)
    odd_calculate_sums(integer, index);
  }
}

// procedure even_calculate_sums(primes, integer)
void Goldbach::even_calculate_sums(int64_t integer, int64_t index) {
// declare prime1 := 0, prime2 := 0
  int64_t prime1 = 0, prime2 = 0;
  // declare index := 0
  int64_t index1 = 0;
  // declare half_integer := integer/2
  int64_t half_integer = integer/2;

  // prime1 := dynamic_array_get(primes, 0)
  prime1 = this->primes[0];
  while (prime1 <= half_integer) {  // while (prime1 <= half_integer) do
    prime2 = integer - prime1;  // prime2 = integer - prime1
    // if (goldbach_is_prime(is_prime_array, prime2)) then
    if (isPrime(prime2)) {
      // triple_elements_array_append(sums_array, 0, prime1, prime2)
      this->outputs[index]
        .goldbachSums.emplace_back(0, prime1, prime2);
    }  // end if
    ++index1;  // ++index
    // prime1 = dynamic_array_get(primes, index)
    prime1 = this->primes[index1];
  }  // end while
}

// procedure odd_calculate_sums(integer, index)
void Goldbach::odd_calculate_sums(int64_t integer, int64_t index) {
    // declare prime1 := 0, prime2 := 0, prime3 := 0
  int64_t prime1 = 0, prime2 = 0, prime3 = 0;
  // declare index := 0, index2 := index
  int64_t index1 = 0, index2 = 0;
  // declare third_integer = integer/3
  int64_t third_integer = integer/3;
  // declare half_integer = integer/2
  int64_t half_integer = integer/2;

  // prime1 := dynamic_array_get(primes, 0)
  prime1 = this->primes[0];
  while (prime1 <= third_integer) {  // while (prime1 <= third_integer) do
    prime2 = prime1;  // prime2 := prime1
    index2 = index;  // index2 := index
    while (prime2 <= half_integer) {  // while (prime2 <= half_integer) do
      // prime3 := integer - prime1 - prime2
      prime3 = integer - prime1 - prime2;
      // if (prime3 >= prime2 and goldbach_is_prime(is_prime_array, prime3))
      if (prime3 >= prime2 && isPrime(prime3))  {
        // triple_elements_array_append(sums_array, prime1, prime2, prime3)
        this->outputs[index]
              .goldbachSums.emplace_back(prime1, prime2, prime3);
      }  // end if
      ++index2;  // ++index2
      // prime2 := dynamic_array_get(primes, index2)
      prime2 = this->primes[index2];
    }  // end while
    ++index1;  // ++index
    // prime1 := dynamic_array_get(primes, index)
    prime1 = this->primes[index1];
  }  // end while
}

// procedure even_calculate_total_sums(integer)
void Goldbach::even_calculate_total_sums(int64_t integer
  , int64_t index) {
      // declare prime1 := 0, prime2 := 0
  int64_t prime1 = 0, prime2 = 0;
  // declare total_sums := 0
  int64_t total_sums = 0;
  // declare index := 0
  int64_t index1 = 0;
  // declare half_integer := integer/2
  int64_t half_integer = integer/2;

  // prime1 := dynamic_array_get(primes, 0)
  prime1 = this->primes[0];
  while (prime1 <= half_integer) {  // while (prime1 <= half_integer) do
    prime2 = integer - prime1;  // prime2 = integer - prime1
    // if (goldbach_is_prime(is_prime_array, prime2)) then
    if (isPrime(prime2)) {
      ++total_sums;  // ++total_sums
    }  // end if
    ++index1;  // ++index
    // prime1 = dynamic_array_get(primes, index)
    prime1 = this->primes[index1];
  }  // end while
  this->outputs[index].totalSums = total_sums;
}

// procedure odd_calculate_total_sums(integer)
void Goldbach::odd_calculate_total_sums(int64_t integer, int64_t index) {
  // declare prime1 := 0, prime2 := 0, prime3 := 0
  int64_t prime1 = 0, prime2 = 0, prime3 = 0;
  // declare total_sums := 0
  int64_t total_sums = 0;
  // declare index := 0, index2 := index
  int64_t index1 = 0, index2 = 0;
  // declare third_integer = integer/3
  int64_t third_integer = integer/3;
  // declare half_integer = integer/2
  int64_t half_integer = integer/2;

  // prime1 := dynamic_array_get(primes, 0)
  prime1 = this->primes[0];
  while (prime1 <= third_integer) {  // while (prime1 <= third_integer) do
    prime2 = prime1;  // prime2 := prime1
    index2 = index;  // index2 := index
    while (prime2 <= half_integer) {  // while (prime2 <= half_integer) do
      // prime3 := integer - prime1 - prime2
      prime3 = integer - prime1 - prime2;
      // if (prime3 >= prime2 and goldbach_is_prime(is_prime_array, prime3))
      if (prime3 >= prime2 && isPrime(prime3))  {
        ++total_sums;  // ++total_sums
      }  // end if
      ++index2;  // ++index2
      // prime2 := dynamic_array_get(primes, index2)
      prime2 = this->primes[index2];
    }  // end while
    ++index1;  // ++index
    // prime1 := dynamic_array_get(primes, index)
    prime1 = this->primes[index1];
  }  // end while
  this->outputs[index].totalSums = total_sums;
}

bool Goldbach::isPrime(int64_t number) {
  return this->isPrimeArray[number];
}

// procedure vector<GoldbachNumber>& getOutputs():
std::vector<GoldbachNumber>& Goldbach::getOutputs() {
  // return this->outputs
  return this->outputs;
}

// procedure vector<int64_t>& getInputs():
std::vector<int64_t>& Goldbach::getInputs() {
  // return this->inputs
  return this->inputs;
// end procedure
}

// procedure vector<int64_t>& :getPrimes():
std::vector<int64_t>& Goldbach::getPrimes() {
  // return this->primes
  return this->primes;
// end procedure
}

// procedure get_number_sums():
GoldbachNumber* Goldbach::get_number_sums() {
  GoldbachNumber* returnOutputs
    = new GoldbachNumber(this->outputs[0].totalSums
      , this->outputs[0].goldbachSums);
  // returnOutputs->goldbachSums(this->outputs[0].goldbachSums);

  returnOutputs->totalSums = this->outputs[0].totalSums;
  return returnOutputs;
}
