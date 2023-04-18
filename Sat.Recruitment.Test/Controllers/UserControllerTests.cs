using System;
using System.Dynamic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Sat.Recruitment.Api.Application.Services;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Api.Domain.DTOs;
using Shouldly;
using Xunit;

namespace Sat.Recruitment.Test.Controllers
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserControllerTests
    {

        private readonly Mock<IUserService> _mockService;

        public UserControllerTests()
        {
            _mockService = new Mock<IUserService>();
        }

        [Fact]
        public async Task AddUser_return_ok_on_success()
        {
            //arrange
            _mockService.Setup(x => x.CreateUser(It.IsAny<UserDTO>()))
                .ReturnsAsync(new UserDTO { Email = "seba1@gmail.com", Money = 180, Address = "Pintos 195", Name = "Seba", Phone = "+541156925433", UserType = "Normal" });

            var controller = new UsersController(_mockService.Object);

            //act
            var result = await controller.Post(new UserDTO { Email = "seba1@gmail.com", Money = 180, Address = "Pintos 195", Name = "Seba", Phone = "+541156925433", UserType = "Normal" });

            var actionResult = result.ShouldBeAssignableTo<ActionResult<UserDTO>>();
            var okObjectResult = actionResult.Result.ShouldBeAssignableTo<OkObjectResult>();
            var value = okObjectResult.Value.ShouldBeAssignableTo<UserDTO>();
            value.Name.ShouldBe("Seba");


        }
    }
}
