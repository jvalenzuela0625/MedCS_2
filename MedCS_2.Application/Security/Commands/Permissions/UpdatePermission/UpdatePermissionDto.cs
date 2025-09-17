using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Application.Security.Commands.Permissions.UpdatePermission
{
    public class UpdatePermissionDto
    {
        public int Id { get; set; }
        public string Module { get; set; } = string.Empty;
        public string OperationType { get; set; } = string.Empty;
        public string Endpoint { get; set; } = string.Empty;
    }
}
