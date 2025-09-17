using MedCS_2.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Domain.Security
{
    public class Roles : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<UserRoles> UserRoles { get; set; } = new List<UserRoles>();
        public ICollection<RolePermissions> RolePermissions { get; set; } = new List<RolePermissions>();
    }
}
