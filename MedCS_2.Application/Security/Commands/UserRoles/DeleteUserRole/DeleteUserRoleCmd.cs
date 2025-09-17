using MedCS_2.Application.Security.Dtos;
using MedCS_2.Shared.Responses;
using MediatR;

namespace MedCS_2.Application.Security.Commands.UserRoles.DeleteUserRole
{
    public record DeleteUserRoleCmd(Guid UserRoleId) : IRequest<Response<UserRoleDto>>;
    
}
