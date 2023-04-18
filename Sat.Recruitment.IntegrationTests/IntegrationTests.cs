using AutoMapper;
using Sat.Recruitment.Api.DTOs;
using Sat.Recruitment.Api.Repositories;
using Sat.Recruitment.Api.Services;
using Shouldly;

namespace Sat.Recruitment.IntegrationTests
{
    public class IntegrationTests
    {
        
        private readonly UserRepository _repo = new();
        private readonly UserService _service;

        public IntegrationTests()
        {
            var profile = new List<Profile>
            {
                new MapperProfile()
            };
            var configuration = new MapperConfiguration(cfg => cfg.AddProfiles(profile));
            IMapper mapper = new Mapper(configuration);

            _service = new UserService(mapper, _repo);
        }

        [Fact]
        public async Task CreateUser_should_return_ok()
        {
            var userDTO = new UserDTO { Email = "seba1@gmail.com", Money = 180, Address = "Pintos 195", Name = "Seba", Phone = "+541156925433", UserType = "Normal" };

            var res = await _service.CreateUser(userDTO);

            res.Name.ShouldBe(userDTO.Name);
            res.Address.ShouldBe(userDTO.Address);
        }
    }
}