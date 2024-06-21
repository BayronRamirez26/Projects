# <span style="color:#FC5656">**Heat Simulation Design**</span>

## <span style="color:#6A4DC3">**Unit of decomposition of the workload and its type of mapping to the threads of execution(OpenMP)**</span>

For this section, the workload distribution solution we devised consists of distributing each plate among the different execution threads, either the default number of threads (Maximum number of CPUs) or the one indicated by the parameter. The distribution by plates is used because at the time of using the resources these are distributed equally; on the other hand, if parts of each plate had been distributed among the execution threads, this would have worsened the performance, because threads would be created and destroyed every time a plate is analyzed, thus becoming a negative implementation.

Design pseudocode is in the following file: [Pseudocode openMP](./design_openmp.pseudo)


## <span style="color:#85BA7D">**Unit of decomposition of the workload and the type of dynamic mapping to processes(MPI)**</span>

For this section, our solution was based on a "dynamic per block" distribution, this can be interpreted as each process would take one block of plates, the block size would consist of the number of threads available to the CPU, this is convenient to incorporate the use of execution threads.

## <span style="color:#50A5C0">**Unit of decomposition of the workload and its type of mapping to the threads of execution(MPI with OpenMP)**</span>

For this section, the solution devised consists of dividing the plate block among the set of execution threads, so that each thread solves a simulation individually and the resources can be used to the maximum by distributing the workload.

Design pseudocode is in the following file: [Pseudocode MPI](./design_distributed.pseudo)
## <span style="color:#64EADE">**Credits**</span>

Copyrigth 2022.

Members:

  - Bayron Ramirez Jimenez <bayron.ramirezjimenez@ucr.ac.cr>
  - Yordi Robles Siles <yordi.robles@ucr.ac.cr>
  - Sebastian Rodriguez Tencio <sebastian.rodrigueztencio@ucr.ac.cr>
  - Enrique Vilchez Lizano <enrique.vilchezlizano@ucr.ac.cr>

Instructor: Alberto Rojas Salazar <alberto.rojassalazar@ucr.ac.cr>

Universidad de Costa Rica. CC BY 4.0