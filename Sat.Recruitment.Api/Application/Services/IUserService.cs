using Sat.Recruitment.Api.Domain.DTOs;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Application.Services
{
    public interface IUserService
    {
        public Task<UserDTO> CreateUser(UserDTO userDTO);
    }
}
