using AutoMapper;
using Sat.Recruitment.Api.Application.Exceptions;
using Sat.Recruitment.Api.Domain;
using Sat.Recruitment.Api.DTOs;
using Sat.Recruitment.Api.Repositories;
using Sat.Recruitment.Api.Strategies;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repo;

        public UserService(IMapper mapper, IUserRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<UserDTO> CreateUser(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);

            var userMoneyCalculator = new UserMoneyCalculator();
            user.Money += userMoneyCalculator.CalculateMoneyToAdd(user.UserType, user.Money);

            if (await _repo.FindDuplicate(user))
                throw new ApiException($"Username, address or email already exists, please provide different values");

            return _mapper.Map<UserDTO>(await _repo.Add(user));

        }
    }
}
