using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Api.Domain;
using Sat.Recruitment.Api.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Application.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);

        Task<List<User>> GetAll();

        Task<bool> FindDuplicate(User user);

        Task<User> Add(User user);


    }
}
