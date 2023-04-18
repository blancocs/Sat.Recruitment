using AutoMapper;
using Moq;
using Sat.Recruitment.Api.Application.Exceptions;
using Sat.Recruitment.Api.Application.Mappers;
using Sat.Recruitment.Api.Application.Repositories;
using Sat.Recruitment.Api.Application.Services;
using Sat.Recruitment.Api.Domain.DTOs;
using Sat.Recruitment.Api.Domain.Models;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace Sat.Recruitment.Test.Services
{
    public class UserServicesTests
    {
        private readonly Mock<IUserRepository> _repo = new ();
        private readonly UserService _service;

        public UserServicesTests()
        {
            var profile = new List<Profile>
            {
                new MapperProfile()
            };
            var configuration = new MapperConfiguration(cfg => cfg.AddProfiles(profile));
            IMapper mapper = new Mapper(configuration);

            _service = new UserService(mapper, _repo.Object);
        }

        [Fact]
        public async Task AddUser_should_return_duplicated()
        {
            var userDTO = new UserDTO { Email = "seba1@gmail.com", Money = 180, Address = "Pintos 195", Name = "Seba", Phone = "+541156925433", UserType = "Normal" };
            try
            {
                _repo.Setup(x =>  x.FindDuplicate(It.IsAny<User>())).ReturnsAsync(true);

                var res = await _service.CreateUser(userDTO);
            }
            catch (ApiException ex)
            {
                ex.Message.ShouldContain("already exists");
            }
        }

        [Fact]
        public async Task AddUser_should_return_ok()
        {
            var userDTO = new UserDTO { Email = "seba1@gmail.com", Money = 100, Address = "Pintos 195", Name = "Seba", Phone = "+541156925433", UserType = "Normal" };
            
             _repo.Setup(x => x.FindDuplicate(It.IsAny<User>())).ReturnsAsync(false);
             _repo.Setup(x => x.Add(It.IsAny<User>())).ReturnsAsync(new User { Email = "seba1@gmail.com", Money = 180, Address = "Pintos 195", Name = "Seba", Phone = "+541156925433", UserType = "Normal" });

            var res = await _service.CreateUser(userDTO);

            res.Name.ShouldBe("Seba");
            res.Email.ShouldBe("seba1@gmail.com");
            res.Address.ShouldBe("Pintos 195");
            
        }
    }
}
