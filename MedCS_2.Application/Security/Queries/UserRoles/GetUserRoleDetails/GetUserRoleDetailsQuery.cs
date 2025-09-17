using MedCS_2.Application.Security.Dtos;
using MedCS_2.Shared.Responses;
using MediatR;

namespace MedCS_2.Application.Security.Queries.UserRoles.GetUserRoleDetails
{
    public record GetUserRoleDetailsQuery(int UserRoleId):IRequest<Response<RolePermissionDto>>;
}
