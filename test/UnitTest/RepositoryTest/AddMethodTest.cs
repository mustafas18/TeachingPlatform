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
        //[Fact]
        //public void Add_Method_DbContext_Should_Be_Called()
        //{

        //    // Arrange
        //    var dbContext = new Mock<AppDbContext>();
        //    var dbSetUserMock = new Mock<DbSet<Guest>>();
        //    dbContext.Setup(x => x.Set<Guest>()).Returns(dbSetUserMock.Object);
        //    var guest = new Guest { Id = 1, Name = "Ol" };
        //    var guest2 = new Guest { Id = 2, Name = "dOl" };

        //    // Act
        //    var repository = new Repository<Guest>(dbContext.Object);
        //    repository.Add(guest);

        //    //Assert
        //    dbContext.Verify(x => x.Set<Guest>());
        //}
        //[Fact]
        //public void Add_Method_Should_Add_Guest1_To_dbSet()
        //{

        //    // Arrange
        //    var dbContext = new Mock<AppDbContext>();
        //    var dbSetUserMock = new Mock<DbSet<Guest>>();
        //    dbContext.Setup(x => x.Set<Guest>()).Returns(dbSetUserMock.Object);
        //    var guest1 = new Guest { Id = 1, Name = "Ol" };
        //    var guest2 = new Guest { Id = 2, Name = "dOl" };

        //    // Act
        //    var repository = new Repository<Guest>(dbContext.Object);
        //    repository.Add(guest1);

        //    //Assert
        //    dbSetUserMock.Verify(x => x.Add(It.Is<Guest>(y => y == guest2)));
        //}

    }
}