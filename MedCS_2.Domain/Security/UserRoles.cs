using MedCS_2.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Domain.Security
{
    public class UserRoles : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime AssignedAt { get; set; }
        public Users User { get; set; } = null!; // Fix: Initialize with null-forgiving operator
        public Roles Role { get; set; } = null!; // Fix: Initialize with null-forgiving operator
    }
}
