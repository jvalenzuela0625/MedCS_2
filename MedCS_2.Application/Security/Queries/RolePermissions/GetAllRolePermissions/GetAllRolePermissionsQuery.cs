using MedCS_2.Application.Security.Dtos;
using MedCS_2.Shared.Responses;
using MediatR;

namespace MedCS_2.Application.Security.Queries.RolePermissions.GetAllRolePermissions
{
    public record GetAllRolePermissionsQuery:IRequest<Response<List<RolePermissionDto>>>;
}
