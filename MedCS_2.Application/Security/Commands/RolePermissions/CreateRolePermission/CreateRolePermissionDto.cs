using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Application.Security.Commands.RolePermissions.CreateRolePermission
{
    public class CreateRolePermissionDto
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
    }
}
