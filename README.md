# TeachingPlatform

Teaching Platform is a platform for teachers and instructors. 

## Features
The platform has the following features
- Online Courses
- Teacher request

## Technical Description

The project have a monolithic architecture. The domain-driven design approach is applied to the project. The project can be a starting point for implementing CQRS/ES patern.

In the project, clients send requests to command services via MediatR. Using the Mediator pattern helps to communicate with multiple objects efficiently in a loosely coupled manner.

Here is  the diagram:

![DDD](https://github.com//mustafas18/TeachingPlatform/blob/master/DesignDiagram.png?raw=true)

To improve consistency and scalability, the repositories are segregated into *ReadRepository* and *Repository*. This segregation reduces merge conflicts while performing multiple operations with data. *ReadRepository* is used for reading operations, and *Repository* is for creating, updating, and deleting operations on database.

I encourage programmers to contribute.
