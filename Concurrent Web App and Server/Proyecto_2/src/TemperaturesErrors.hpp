/**
 * @copyright Copyright (c) 2022
 * @file TemperaturesErrors.hpp
 * @author Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
 * @author Yordi Robles Siles <yordi.robles@ucr.ac.cr>
 * @author Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
 * @author Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>
 * @brief File to store errors
 * @version 0.1
 * @date 2022-11-13
 */
#ifndef TEMPERATURE_ERRORS_HPP
#define TEMPERATURE_ERRORS_HPP

// define SUCCESS as 0
#define SUCCESS 0
// define ARGUMENT_ERROR as 1
#define ARGUMENT_ERROR 1
// define ARGUMENT_HELP_ERROR as 2
#define ARGUMENT_HELP_ERROR 2
// define INVALID_FILE_ERROR as 3
#define INVALID_FILE_ERROR 3
// define JOB_FILE_ERROR as 4
#define JOB_FILE_ERROR 4
// define STREAM_ERROR as 5
#define STREAM_ERROR 5
// define DISTRIBUTED_ERROR as 6
#define DISTRIBUTED_ERROR 6

#define fail(message) throw std::runtime_error(message)

#endif  // TEMPERATURE_ERRORS_HPP
