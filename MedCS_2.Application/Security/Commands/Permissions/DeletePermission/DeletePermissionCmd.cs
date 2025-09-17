using MedCS_2.Application.Security.Dtos;
using MedCS_2.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Application.Security.Commands.Permissions.DeletePermission
{
    public record DeletePermissionCmd(int PermissionId):IRequest<Response<PermissionDto>>;
}
