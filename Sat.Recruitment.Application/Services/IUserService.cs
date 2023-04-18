using Sat.Recruitment.Api.DTOs;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Services
{
    public interface IUserService
    {
        public Task<UserDTO> CreateUser(UserDTO userDTO);
    }
}
