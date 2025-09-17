using MedCS_2.Application.Security.Dtos;
using MedCS_2.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Application.Security.Queries.Permissions.GetAllPermissions
{
    public record GetAllPermissionsQuery : IRequest<Response<List<PermissionDto>>>;

}
