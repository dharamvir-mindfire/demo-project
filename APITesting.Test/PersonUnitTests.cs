using Xunit;
using Moq;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DemoProject.Models;
using DemoProject.Services;
using DemoProject.Database; // Replace with your actual namespace


namespace DemoProject.Test
{
    public class PersonServicesTests
    {
        [Fact]
        public void GetAll_ReturnsData()
        {
            // Arrange
            var mockDbContext = new Mock<AppDbContext>();

            // Mock DbSet<Person> and setup mock data
            var mockDbSet = new Mock<DbSet<Person>>();
            var persons = new List<Person>
                {
                    new Person { Id = 1, Name = "John Doe", Email = "john.doe@example.com", PhoneNumber = "1234567890", Address = "123 Main St" },
                    new Person { Id = 2, Name = "Jane Smith",Email = "john.smith@example.com", PhoneNumber = "1234567890", Address = "123 Main St" }
                }.AsQueryable();

            mockDbSet.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(persons.Provider);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(persons.Expression);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(persons.ElementType);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(persons.GetEnumerator());

            // Setup DbContext to return mocked DbSet
            mockDbContext.Setup(c => c.Persons).Returns(mockDbSet.Object);

            var personServices = new PersonServices(mockDbContext.Object);

            // Act
            var response = personServices.GetAll();

            // Assert
            Assert.Equals(response.StatusCode, 200);
            Assert.Equals(2, response?.Data?.Count()); // Assuming GetAll returns IEnumerable<Person>
        }
    }
}
