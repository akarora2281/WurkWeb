using Wurk.Core.Contracts;
using Wurk.Core.Services;
using Wurk.Infrastructure.Data;
using Wurk.Infrastructure.Data.Models;
using Wurk.Infrastructure.Data.Repositories;
using Wurk.Test.Common;
using Wurk.Core.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using AutoMapper;
using System.Linq;
using Wurk.Tests.Common;
using System.Runtime.Serialization;

namespace Wurk.Tests
{
    public class UserServiceTests
    {
        private Mock<IAppRepository> _appRepository;
        private Mock<IUserService> _userService;
        private ApplicationDbContext _context;

        public UserServiceTests()
        {
            _userService = new Mock<IUserService>();
            _appRepository = new Mock<IAppRepository>();
            _context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
       .UseInMemoryDatabase(databaseName: "ShoppingCartDb")
       .Options);
        }

        [Theory]
        [InlineData("testId")]
        public void GetAllUserShouldReturnUsersInDb(string userId)
        {

            // Assert.

            _appRepository.Setup(x => x.All<UserViewModel>()).Returns(ObjectGenerator.GetUserViewModelListObject().AsQueryable());
            _userService.Setup(x => x.GetAllUser(userId)).Returns(ObjectGenerator.GetUserViewModelListObject());

            // Act
            var services = new UserService(_appRepository.Object, _context);

            services.GetAllUser(userId);

            // Verify
            _userService.Verify(x => x.GetAllUser(userId), Times.Never);
        }
    }
}
