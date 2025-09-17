using AutoMapper;
using MedCS_2.Application.Security.Commands.Users.CreateUser;
using MedCS_2.Application.Security.Commands.Users.UpdateUser;
using MedCS_2.Application.Security.Dtos;
using MedCS_2.Domain.Security;

namespace MedCS_2.Application.Security.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<Users, UserDto>().ReverseMap();
            CreateMap<CreateUserDto, Users>();
            CreateMap<UpdateUserDto, Users>();
        }
    }
}
