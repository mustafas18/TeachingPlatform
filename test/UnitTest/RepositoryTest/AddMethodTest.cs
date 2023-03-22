using Core.Entities;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using Xunit.Sdk;

namespace UnitTest.RepositoryTest
{
    public class AddMethodTest
    {

        ///*
        // This class mock the DbContext and DbSet, then the class call the Add method of the repository, 
        // and finally, it is verified that those methods from mock objects have been called.
        // */
        [Fact]
        public void Add_Method_DbContext_Should_Be_Called()
        {

            // Arrange
            var dbContext = new Mock<AppDbContext>();
            var dbSetCourseMock = new Mock<DbSet<Course>>();
            dbContext.Setup(x => x.Set<Course>()).Returns(dbSetCourseMock.Object);
            var course = new Course { Id = 1, TitleEn="Course1" };
            var course2 = new Course { Id = 2, TitleEn = "Course2" };

            // Act
            var repository = new Repository<Course>(dbContext.Object);
            repository.Add(course);

            //Assert
            dbContext.Verify(x => x.Set<Course>());
        }
        [Fact]
        public void Add_Method_Should_Add_Guest1_To_dbSet()
        {

            // Arrange
            var dbContext = new Mock<AppDbContext>();
            var dbSetUserMock = new Mock<DbSet<Course>>();
            dbContext.Setup(x => x.Set<Course>()).Returns(dbSetUserMock.Object);
            var course = new Course { Id = 1, TitleEn = "Course1" };
            var course2 = new Course { Id = 2, TitleEn = "Course2" };

            // Act
            var repository = new Repository<Course>(dbContext.Object);
            repository.Add(course);

            //Assert
            dbSetUserMock.Verify(x => x.Add(It.Is<Course>(y => y == course)));
        }

    }
}