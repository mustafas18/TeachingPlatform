# TeachingPlatform

Teaching Platform is a platform for teachers and instructors. 

## Features
The platform has the following features
- Online Courses
- Teacher request

## Technical Description

The project has a monolithic architecture. The domain-driven design approach is applied to the project.

In the project, clients send requests to command services via MediatR. 
The command patern decouple classes that invoke operations from classes that perform these operations. As a result it improves single responsibility principle. 
Using the Mediator pattern reduce chaotic dependencies between repositories, services and controllers.

Here is  the diagram:

![DDD](https://github.com//mustafas18/TeachingPlatform/blob/master/DesignDiagram.png?raw=true)

To improve consistency and scalability, the repositories are segregated into *ReadRepository* and *Repository*. This segregation reduces merge conflicts while performing multiple operations with data. 

*ReadRepository* is used for reading operations, while *Repository* is for creating, updating, and deleting operations on database.

Most developers use *CachedRepository*, which usually overrides the methods of the base repository. As a result, the life time of CachedRepository is the same as base repository.

The *ReadRepository* uses IMemoryCache, therefore, it can be regarded as an independent *CachedRepository*. However, it has different lifetime.


I encourage programmers to contribute.

Best regard,
S. Mustafa Bazghandi
