# **Design**

## **Visual description**

This project has a visual design to understand better the type of solution implemented. As it was mentioned in the project description (see [Project_README](./../../README.md)), the solution is based in the producer-consumer pattern.

![Concurrent Server Design](ConcurrentServerDesign.svg)

This design represents the buffer used by the consumers/producers with an arrow. The squares that are atop of this arrow are the products that will be taken to the consumers/connectionHandlers. The data flow shows how the connection handlers receive certain parameters, in this case numbers, and process them with the help of the webApp, which is executing an algorithm to find the Goldbach sums of the requested numbers. Finally, these outputs return as a reponse to the clients.

## **Algorithms**

These were some of the implemented algoritms and procedures used to solve the problem:

### Goldbach

This were some of the implemented procedures: [Goldbach](./Goldbach.pseudo)

### GoldbachWebApp

This were some of the implemented procedures: [GoldbachWebApp](./GoldbachWebApp.pseudo)

### HttpConnectionHandler

This were some of the implemented procedures: [HttpConnectionHandler](./HttpServer.pseudo)

### HttpServer

This were some of the implemented procedures: [HttpServer](./HttpServer.pseudo)