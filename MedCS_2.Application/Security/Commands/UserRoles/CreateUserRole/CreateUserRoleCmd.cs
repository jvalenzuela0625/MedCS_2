using MedCS_2.Application.Security.Dtos;
using MedCS_2.Shared.Responses;
using MediatR;

namespace MedCS_2.Application.Security.Commands.UserRoles.CreateUserRole
{
    public record CreateUserRoleCmd(CreateUserRoleDto CreateUsrRoleDto):IRequest<Response<UserRoleDto>>;
}
