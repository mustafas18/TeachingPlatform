# TeachingPlatform

Teaching Platform is a platform for teachers and instructors. 

## Features
The platform has the following features
- Online Courses
- Teacher request

## Technical Description

The project is based on monolithic architecture. 
In the project, The domain-driven design approach is applied. However, event store is not implemented yet. 
I encourage programmers to contribute.

In the project, clients sends request to command services. MediatR is used in the controllers. Using Mediator pattern in controller is my idea, which may be criticised by other developers. Here is  the diagram:

Cient ---> Command Sevice ---> Event
                 |
                 |
                 Repository




