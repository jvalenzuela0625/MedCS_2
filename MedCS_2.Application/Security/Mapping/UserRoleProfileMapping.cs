using AutoMapper;
using MedCS_2.Application.Security.Commands.UserRoles.CreateUserRole;
using MedCS_2.Application.Security.Commands.UserRoles.UpdateUserRole;
using MedCS_2.Application.Security.Dtos;
using MedCS_2.Domain.Security;

namespace MedCS_2.Application.Security.Mapping
{
    public class UserRoleProfileMapping : Profile
    {
        public UserRoleProfileMapping()
        {
            CreateMap<UserRoles,UserRoleDto>().ReverseMap();
            CreateMap<CreateUserRoleDto, UserRoles>();
            CreateMap<UpdateUserRoleDto, UserRoles>();
        }
    }
}
