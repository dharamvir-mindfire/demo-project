using DemoProject.Dtos;
using DemoProject.Helpers;
using DemoProject.Models;
using DemoProject.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;

namespace DemoProject.Test
{
    public class AuthServicesTests
    {
        private readonly AuthServices authServices;
        private readonly AuthHelpers authHelpers;
        private readonly List<ApplicationUser> _users = new List<ApplicationUser>
            {
                 new ApplicationUser() { Id = "6da5264a-d3c7-43af-b772-7fe9fee1e0d3", UserName="dharamvir1@mindfiresolutions.com", PasswordHash="AQAAAAIAAYagAAAAEPIlhGUuGfhxth2NFR4AAyxAAMI7NnQ2rHjEJg1mlpOpscZD1fgdYGoOYGSj8Oqq/Q==" },
            };
        private readonly Dictionary<string, IList<string>> _userRoles = new Dictionary<string, IList<string>>
        {
            { "6da5264a-d3c7-43af-b772-7fe9fee1e0d3", new List<string> { "Customer" } }
        };

public Mock<UserManager<TUser>> MockUserManager<TUser>(List<TUser> ls) where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Object.UserValidators.Add(new UserValidator<TUser>());
            mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>());

            mgr.Setup(m => m.FindByNameAsync(It.IsAny<string>()))
            .Returns((string userName) => Task.FromResult(this._users.FirstOrDefault(u => u.UserName == userName)));

            mgr.Setup(m => m.CheckPasswordAsync(It.IsAny<TUser>(), It.IsAny<string>()))
            .ReturnsAsync(true);

            mgr.Setup(m => m.GetRolesAsync(It.IsAny<TUser>()))
            .ReturnsAsync((ApplicationUser user) => _userRoles.ContainsKey(user.Id) ? _userRoles[user.Id] : new List<string>());

            mgr.Setup(x => x.DeleteAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);
            mgr.Setup(x => x.CreateAsync(It.IsAny<TUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success).Callback<TUser, string>((x, y) => ls.Add(x));
            mgr.Setup(x => x.AddToRoleAsync(It.IsAny<TUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
            mgr.Setup(x => x.UpdateAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);

            return mgr;
        }

        public AuthServicesTests()
        {
            var mockConfig = new Mock<IConfiguration>();
            mockConfig.SetupGet(x => x["jwt:issuer"]).Returns("202f6ea2-125a-45e8-9d44-2aeba27c2597-4c2e882d-e965-41e9-a965-f16ef1aabd3a-49142a05-bc6a-4f78-ab10-650497afe7aa");
            mockConfig.SetupGet(x => x["jwt:key"]).Returns("02d9cafd-c581-4f94-8bde-9c6452d24501");
            var userManager = MockUserManager<ApplicationUser>(_users);
            authHelpers = new AuthHelpers(mockConfig.Object);
            authServices = new AuthServices(userManager.Object, authHelpers);
        }
        [Fact]
        public async void Login()
        {
            // Act
            var payload = new LoginDto
            {
                UserName = "dharamvir1@mindfiresolutions.com",
                Password = "Nokia@123"
            };
            var response = await authServices.Login(payload);

            // Assert
            Assert.Equal(response.StatusCode, 200);
        }
        [Fact]
        public async void Register()
        {
            // Act
            var payload = new RegistrationDto
            {
                FullName = "Dharamvir",
                Email = "dharamvir1@mindfiresolutions.com",
                UserName = "dharamvir1@mindfiresolutions.com",
                PhoneNumber = "9999955555",
                Password = "Nokia@123"
            };
            var response = await authServices.Register(payload);

            // Assert
            Assert.Equal(response.StatusCode, 200);
        }
    }
}
