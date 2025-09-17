using MedCS_2.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Domain.Security
{
    public class RolePermissions : BaseEntity<int>
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        public Roles Role { get; set; } = null!; // Fix: Initialize with null-forgiving operator
        public Permissions Permission { get; set; } = null!; // Fix: Initialize with null-forgiving operator
    }
}
