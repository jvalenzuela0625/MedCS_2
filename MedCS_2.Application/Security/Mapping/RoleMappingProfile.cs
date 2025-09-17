using AutoMapper;
using MedCS_2.Application.Security.Commands.Roles.CreateRole;
using MedCS_2.Application.Security.Commands.Roles.UpdateRole;
using MedCS_2.Application.Security.Dtos;
using MedCS_2.Domain.Security;

namespace MedCS_2.Application.Security.Mapping
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<Roles, RoleDto>().ReverseMap();
            CreateMap<CreateRoleDto, Roles>();
            CreateMap<UpdateRoleDto, Roles>();
        }
    }
}
