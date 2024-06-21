/*
 * Copyright 2022 Enrique Vilchez <enrique.vilchezlizano@ucr.ac.cr> CC-BY 4.0
 */

#ifndef MPI_HPP
#define MPI_HPP

#include <mpi.h>

#include <cstring>
#include <string>
#include <vector>

#include "MpiError.hpp"

// Fail exception: message
#define fail1(msg) throw MpiError(msg)
// Fail exception: hostname:process_number: message
#define fail2(msg, mpi) throw MpiError(msg, mpi)
// Fail exception: hostname:process_number.thread_number: message
#define fail3(msg, mpi, thrN) throw MpiError(msg, mpi, thrN)

// Mpi any tag
#define any_tag MPI_ANY_TAG
// Mpi any process
#define any_process MPI_ANY_SOURCE

/**
 * @brief Class Mpi
 * @details Wrapper for the mpi initialization process
 * 
 */
class Mpi {
/*---------------------------------ATTRIBUTES---------------------------------*/
 protected:
  int processNumber = -1;  /**< Process number */
  int processCount = -1;  /**< Total processes */
  std::string hostname = "";  /**< Process' host name */
/*---------------------------------ATTRIBUTES---------------------------------*/
/*----------------------------------MAPPING-----------------------------------*/
 public:  // Mapping for each datatype to MPI_Datatype
  /// @brief Mapping for boolean
  static inline int map(bool) { return MPI_C_BOOL; }
  /// @brief Mapping for char
  static inline int map(char) { return MPI_CHAR; }
  /// @brief Mapping for unsigned char
  static inline int map(unsigned char) { return MPI_UNSIGNED_CHAR; }
  /// @brief Mapping for short
  static inline int map(short) { return MPI_SHORT; }
  /// @brief Mapping for undigned short
  static inline int map(unsigned short) { return MPI_UNSIGNED_SHORT; }
  /// @brief Mapping for integer
  static inline int map(int) { return MPI_INT; }
  /// @brief Mapping for unsigned integer
  static inline int map(unsigned) { return MPI_UNSIGNED; }
  /// @brief Mapping for long
  static inline int map(long) { return MPI_LONG; }
  /// @brief Mapping for unsigned long
  static inline int map(unsigned long) { return MPI_UNSIGNED_LONG; }
  /// @brief Mapping for long long
  static inline int map(long long) { return MPI_LONG_LONG; }
  /// @brief Mapping for unsigned long long
  static inline int map(unsigned long long) { return MPI_UNSIGNED_LONG_LONG; }
  /// @brief Mapping for float
  static inline int map(float) { return MPI_FLOAT; }
  /// @brief Mapping for double
  static inline int map(double) { return MPI_DOUBLE; }
  /// @brief Mapping for long double
  static inline int map(long double) { return MPI_LONG_DOUBLE; }
  /// @brief Mapping for string
  static inline int map(std::string) { return MPI_CHAR; }
/*----------------------------------MAPPING-----------------------------------*/

 public:
  /**
   * @brief Construct a new Mpi wrapper
   * @details Needs the arguments form the main procedure
   * 
   * @param argc argument count
   * @param argv argument vector
   */
  explicit Mpi(int& argc, char* argv[]) {
    // Initialize Mpi execution environment
    if (MPI_Init(&argc, &argv) != MPI_SUCCESS)
      fail1("Could not initialize Mpi execution environment");
    // Initialize process rank
    if (MPI_Comm_rank(MPI_COMM_WORLD, &this->processNumber) != MPI_SUCCESS)
      fail1("Could not obtain process rank");
    // Initialize process count
    if (MPI_Comm_size(MPI_COMM_WORLD, &this->processCount) != MPI_SUCCESS)
      fail1("Could not obtain process count");
    // Initialize process host name
    char process_hostname[MPI_MAX_PROCESSOR_NAME] = { '\0' };
    int hostname_length = -1;
    if (MPI_Get_processor_name(process_hostname, &hostname_length)
      != MPI_SUCCESS)
      fail1("Could not obtain process host name");
    this->hostname = process_hostname;
  }

  /**
   * @brief Destroy the Mpi wrapper
   * @details Finalize the mpi execution environment
   * 
   */
  ~Mpi() {
    MPI_Finalize();
  }
/*-----------------------------------SENDS------------------------------------*/
  /**
   * @brief Send a message to a process
   * @details Default tag value set to 0
   * 
   * @tparam DataType data type to send
   * @param value value to send
   * @param toProcess to which process number
   * @param tag tag of the message
   */
  template<class DataType>
  void send(DataType value, int toProcess, int tag = 0) {
    if (MPI_Send(&value, /*count*/ 1, /*Datatype */ map(value)
      , /*target*/ toProcess, /*tag*/ tag, MPI_COMM_WORLD) != MPI_SUCCESS) {
      fail2("Could not send message", *this);
    }
  }

  /**
   * @brief Send an array as a message to a process
   * @details Default tag value set to 0
   * This takes the address of the value. Should be used to send arrays
   * 
   * @tparam DataType data type to send
   * @param values array to send
   * @param count number of datatypes to send
   * @param toProcess to which process number
   * @param tag tag of the message
   */
  template<class DataType>
  void send(DataType* values, int count, int toProcess, int tag = 0) {
    if (MPI_Send(count, /*count*/ 1, map(count), /*target*/ toProcess
      , /*tag*/ tag, MPI_COMM_WORLD) != MPI_SUCCESS) {
      fail2("Could not send array", *this);
    }
    if (MPI_Send(values, /*count*/ count, map(DataType()), /*target*/ toProcess
      , /*tag*/ tag, MPI_COMM_WORLD) != MPI_SUCCESS) {
      fail2("Could not send array", *this);
    }
  }


  /**
   * @brief Send a vector to a process
   * @details Default tag value set to 0
   * 
   * @tparam DataType data type to send
   * @param values values to send
   * @param toProcess to which process number
   * @param count number of datatypes to send
   * @param tag tag of the message
   */
  template<class DataType>
  void send(const std::vector<DataType>& values, int toProcess, int count = 0
    , int tag = 0) {
    if (count == 0) {
      size_t value_count = values.size();
      if (MPI_Send(&value_count, /*count*/ 1, map(value_count)
        , /*target*/ toProcess, /*tag*/ tag, MPI_COMM_WORLD) != MPI_SUCCESS) {
        fail2("Could not send vector count", *this);
      }
      count = value_count;
    }
    if (MPI_Send(&values[0], count, map(DataType()), /*target*/ toProcess
      , /*tag*/ tag, MPI_COMM_WORLD) != MPI_SUCCESS) {
      fail2("Could not send vector", *this);
    }
  }

  /**
   * @brief Send a string to a process
   * @details Default tag value set to 0
   * 
   * @param text text to send
   * @param toProcess to which process number
   * @param tag tag of the message
   */
  void send(std::string& text, int toProcess, int tag = 0) {
    char buffer[text.length()];
    strncpy(buffer, text.c_str(), text.length());
    if (MPI_Send(buffer, text.length(), map(text), /*target*/ toProcess
      , /*tag*/ tag, MPI_COMM_WORLD) != MPI_SUCCESS) {
      fail2("Could not send text", *this);
    }
  }
/*-----------------------------------SENDS------------------------------------*/
/*---------------------------------RECEIVES-----------------------------------*/
  /**
   * @brief Receive a message from a process
   * @details Default tag value set to any_tag and default process set to any.
   * Should be used to receive vectors
   * 
   * @tparam DataType data type to receive
   * @param value value to receive the message
   * @param fromProcess from which process await a message
   * @param tag tag of the message
   */
  template<class DataType>
  void receive(DataType& value, int fromProcess = any_process
    , int tag = any_tag) {
    if (MPI_Recv(&value, /*capacity*/ 1, map(value), /*source*/ fromProcess
      , /*tag*/ tag, MPI_COMM_WORLD, MPI_STATUS_IGNORE) != MPI_SUCCESS) {
      fail2("Could not receive message", *this);
    }
  }

  /**
   * @brief Receive an array from a process
   * @details Default tag value set to any_tag and default process set to any.
   * 
   * @tparam DataType data type to receive
   * @param values array to receive the message
   * @param capacity number of datatypes to receive
   * @param fromProcess from which process await a message
   * @param tag tag of the message
   */
  template<class DataType>
  void receive(DataType* values, int capacity = 0, int fromProcess = any_process
    , int tag = any_tag) {
    size_t value_count = 0;
    if (MPI_Recv(&value_count, /*capacity*/ 1, map(size_t()), fromProcess
    , /*tag*/ tag, MPI_COMM_WORLD, MPI_STATUS_IGNORE) != MPI_SUCCESS) {
      fail2("Could not receive vector count", *this);
    }
    if (capacity == 0) {
      capacity = value_count;
    }
    if (MPI_Recv(values, /*capacity*/ capacity, map(DataType())
      , /*source*/ fromProcess, /*tag*/ tag, MPI_COMM_WORLD
      , MPI_STATUS_IGNORE) != MPI_SUCCESS) {
      fail2("Could not receive array", *this);
    }
  }

  /**
   * @brief Receive a vector from a process
   * @details Default tag value set to any_tag and default process set to any.
   * 
   * @tparam DataType data type to receive
   * @param values vector to receive the message
   * @param capacity number of datatypes to receive
   * @param fromProcess from which process await a message
   * @param tag tag of the message
   */
  template<class DataType>
  void receive(std::vector<DataType>& values, int fromProcess = any_process
    , int capacity = 0, int tag = any_tag) {
    if (capacity == 0) {
      size_t value_count = 0;
      if (MPI_Recv(&value_count, /*capacity*/ 1, map(size_t()), fromProcess
      , /*tag*/ tag, MPI_COMM_WORLD, MPI_STATUS_IGNORE) != MPI_SUCCESS) {
        fail2("Could not receive vector count", *this);
      }
      values.resize(value_count);
      capacity = value_count;
    }
    if (MPI_Recv(&values[0], capacity, map(DataType())
      , /*source*/ fromProcess, /*tag*/ tag, MPI_COMM_WORLD
      , MPI_STATUS_IGNORE) != MPI_SUCCESS) {
      fail2("Could not receive vector", *this);
    }
  }
  /**
   * @brief Receive a vector from a process
   * @details Default tag value set to any_tag and default process set to any.
   * 
   * @param text string to receive the text
   * @param capacity number of characters to receive
   * @param fromProcess from which process await a message
   * @param tag tag of the message
   */
  void receive(std::string& text, int capacity, int fromProcess = any_process
    , int tag = any_tag) {
    char buffer[capacity];
    if (MPI_Recv(buffer, /*capacity*/ capacity, map(text)
      , /*source*/ fromProcess, /*tag*/ tag, MPI_COMM_WORLD
      , MPI_STATUS_IGNORE) != MPI_SUCCESS) {
      fail2("Could not receive text", *this);
    }
    text = buffer;
  }
/*---------------------------------RECEIVES-----------------------------------*/
/*-------------------------------BROADCASTS-----------------------------------*/
  /**
   * @brief Broadcast a message to a process
   * @details Default root set to 0
   * 
   * @tparam DataType data type to broadcast
   * @param value value to broadcast
   * @param root which process is broadcasting
   */
  template<class DataType>
  void broadcast(DataType& value, int root = 0) {
    if (MPI_Bcast(&value, /*count*/ 1, map(value), root, MPI_COMM_WORLD)
      != MPI_SUCCESS ) {
      fail2("Could not broadcast message", *this);
    }
  }

  /**
   * @brief Broadcast an array as a message to a process
   * @details Default root set to 0
   * This takes the address of the value. Should be used to broadcast arrays
   * 
   * @tparam DataType data type to broadcast
   * @param values array to broadcast
   * @param count number of datatypes to broadcast
   * @param root which process is broadcasting
   */
  template<class DataType>
  void broadcast(DataType* values, int count, int root = 0) {
    if (MPI_Bcast(&count, /*count*/ 1, map(count), root, MPI_COMM_WORLD)
      != MPI_SUCCESS ) {
      fail2("Could not broadcast array count", *this);
    }
    if (MPI_Bcast(values, count, map(DataType()), root, MPI_COMM_WORLD)
      != MPI_SUCCESS ) {
      fail2("Could not broadcast message", *this);
    }
  }

  /**
   * @brief Broadcasts a vector
   * @details Default root set to 0
   * 
   * @tparam DataType data type to broadcast
   * @param values vector to broadcast
   * @param count number of datatypes to broadcast
   * @param root which process is broadcasting
   */
  template<class DataType>
  void broadcast(std::vector<DataType>& values, int count = 0, int root = 0) {
    if (count == 0) {
      size_t value_count = values.size();
      if (MPI_Bcast(&value_count, /*count*/ 1, map(value_count), root
        , MPI_COMM_WORLD) != MPI_SUCCESS ) {
        fail2("Could not broadcast vector count", *this);
      }
      count = value_count;
    }
    if (MPI_Bcast(&values[0], count, map(DataType()), root, MPI_COMM_WORLD)
      != MPI_SUCCESS ) {
      fail2("Could not broadcast vector", *this);
    }
  }

  /**
   * @brief Broadcast a string
   * @details Default root set to 0
   * 
   * @param text text to broadcast
   * @param capacity number of characters to broadcast (send could be 0, but
   * receiveing REQUIRES a capacity)
   * @param root which process is broadcasting
   */
  void broadcast(std::string& text, int capacity, int root = 0) {
    if (capacity == 0) {
      char buffer[text.length()];
      strncpy(buffer, text.c_str(), text.length());
      if (MPI_Bcast(buffer, text.length(), map(text), root, MPI_COMM_WORLD)
        != MPI_SUCCESS ) {
        fail2("Could not broadcast text", *this);
      }
    } else {
      char buffer[capacity];
      if (MPI_Bcast(buffer, capacity, map(text), root, MPI_COMM_WORLD)
        != MPI_SUCCESS ) {
        fail2("Could not broadcast text", *this);
      }
      text = buffer;
    }
  }
/*-------------------------------BROADCASTS-----------------------------------*/
/*---------------------------------GETTERS------------------------------------*/
  /**
   * @brief Get the process number
   * 
   * @return int process number
   */
  inline int getProcessNumber() const {
    return this->processNumber;
  }

  /**
   * @brief Get the process count
   * 
   * @return int process count
   */
  inline int getProcessCount() const {
    return this->processCount;
  }

  /**
   * @brief Get the process' host name
   * 
   * @return int 
   */
  inline std::string getHostname() const {
    return this->hostname;
  }

  /**
   * @brief Get the process number
   * 
   * @return int process number
   */
  inline int rank() const {
    return this->processNumber;
  }

  /**
   * @brief Get the process count
   * 
   * @return int process count
   */
  inline int size() const {
    return this->processCount;
  }
  /**
   * @brief Get the time
   * 
   * @return double time
   */
  inline double getTime() const {
    return MPI_Wtime();
  }
/*---------------------------------GETTERS------------------------------------*/
};
#endif  // MPI_HPP
