using DemoProject.Database;
using DemoProject.Dtos;
using DemoProject.Models;
using DemoProject.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace DemoProject.Test
{
    public class PersonServicesTests
    {
        private readonly PersonServices personServices;
        public PersonServicesTests()
        {
            // Arrange

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "DemoProject")
            .Options;
            var mockDbContext = new Mock<AppDbContext>(options);

            // Mock DbSet<Person> and setup mock data
            var mockDbSet = new Mock<DbSet<Person>>();
            var persons = new List<Person>
                {
                    new Person { Id = 1, Name = "John Doe", Email = "john.doe@example.com", PhoneNumber = "1234567890", Address = "123 Main St" },
                    new Person { Id = 2, Name = "Jane Smith",Email = "john.smith@example.com", PhoneNumber = "1234567890", Address = "123 Main St" }
                }.AsQueryable();

            mockDbSet.Setup(m => m.Find(It.IsAny<object>())).Returns<object[]>(ids => persons.FirstOrDefault(p => p.Id == (Int64)ids[0]));

            mockDbSet.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(persons.Provider);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(persons.Expression);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(persons.ElementType);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(persons.GetEnumerator());

            // Setup DbContext to return mocked DbSet
            mockDbContext.Setup(c => c.Persons).Returns(mockDbSet.Object);
            personServices = new PersonServices(mockDbContext.Object);
        }
        [Fact]
        public void GetAll()
        {
            // Act
            var response = personServices.GetAll();

            // Assert
            Assert.Equal(response.StatusCode, 200); // Assuming GetAll returns IEnumerable<Person>
            Assert.Equal(2, response?.Data?.Count()); // Assuming GetAll returns IEnumerable<Person>
        }
        [Fact]
        public void Get()
        {
            // Act
            var response = personServices.Get(2);

            // Assert
            Assert.Equal(response.StatusCode, 200); // Assuming GetAll returns IEnumerable<Person>
            Assert.True(response?.Data != null); // Assuming GetAll returns IEnumerable<Person>
        }
        [Fact]
        public void Add()
        {
            // Act
            var payload = new PersonDto
            {
                Name = "Dharamvir",
                Email = "dharamvir1@mindfiresolutions.com"
            };
            var response = personServices.Add(payload);

            // Assert
            Assert.Equal(response.StatusCode, 200); // Assuming GetAll returns IEnumerable<Person>
            Assert.True(response?.Data != null); // Assuming GetAll returns IEnumerable<Person>
        }
        [Fact]
        public void Update()
        {
            // Act
            var payload = new PersonDto
            {
                Id = 2,
                Name = "Dharamvir",
                Email = "dharamvir1@mindfiresolutions.com"
            };
            var response = personServices.Update(payload);

            // Assert
            Assert.Equal(response.StatusCode, 200); // Assuming GetAll returns IEnumerable<Person>
            Assert.True(response?.Data != null); // Assuming GetAll returns IEnumerable<Person>
        }
    }
}
