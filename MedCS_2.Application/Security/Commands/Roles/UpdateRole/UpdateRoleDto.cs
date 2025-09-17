using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Application.Security.Commands.Roles.UpdateRole
{
    public class UpdateRoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
