using AutoMapper;
using MedCS_2.Application.Security.Commands.Permissions.CreatePermission;
using MedCS_2.Application.Security.Commands.Permissions.UpdatePermission;
using MedCS_2.Application.Security.Dtos;
using MedCS_2.Domain.Security;

namespace MedCS_2.Application.Security.Mapping
{
    public class PermissionMappingProfile : Profile
    {
        public PermissionMappingProfile()
        {
            CreateMap<Permissions, PermissionDto>().ReverseMap();
            CreateMap<CreatePermissionDto, Permissions>();
            CreateMap<UpdatePermissionDto, Permissions>();
        }
    }
}
