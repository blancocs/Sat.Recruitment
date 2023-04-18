using AutoMapper;
using Sat.Recruitment.Api.Domain;

namespace Sat.Recruitment.Api.DTOs
{
    public class MapperProfile:Profile
    {
        public MapperProfile() {
            CreateMap<UserDTO, User>();
            CreateMap<User,UserDTO>();
        }
    }
}
