using MedCS_2.Application.Security.Dtos;
using MedCS_2.Shared.Responses;
using MediatR;

namespace MedCS_2.Application.Security.Commands.UserRoles.UpdateUserRole
{
    public record UpdateUserRoleCmd(UpdateUserRoleDto UserRoleDto):IRequest<Response<UserRoleDto>>;
}
