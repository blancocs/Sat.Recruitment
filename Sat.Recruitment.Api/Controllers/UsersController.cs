using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using Sat.Recruitment.Api.Application.Services;
using Sat.Recruitment.Api.Domain.DTOs;

namespace Sat.Recruitment.Api.Controllers
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Errors { get; set; }
    }

    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _service;

        public UsersController( IUserService service)
        {
           _service = service;
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [MapToApiVersion("1")]
        public async Task<ActionResult<UserDTO>> Post(UserDTO user) 
        {
            return Ok( await _service.CreateUser(user));

            
        }

       
    }

}
