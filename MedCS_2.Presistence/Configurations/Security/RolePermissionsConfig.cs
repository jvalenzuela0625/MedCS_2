using MedCS_2.Domain.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Presistence.Configurations.Security
{
    public class RolePermissionsConfig : IEntityTypeConfiguration<RolePermissions>
    {
        public void Configure(EntityTypeBuilder<RolePermissions> builder)
        {
            // Set primary key (inherited from BaseEntity<Guid>)
            builder.HasKey(rp => rp.Id);

            // Configure foreign key to Roles
            builder.Property(rp => rp.RoleId).IsRequired();
            // Configure foreign key to Permissions
            builder.Property(rp => rp.PermissionId).IsRequired();

            // Define relationship: One Role has many RolePermissions
            builder.HasOne(rp => rp.Role)           // Each RolePermission has one Role
                .WithMany(r => r.RolePermissions)   // Each Role has many RolePermissions
                .HasForeignKey(rp => rp.RoleId)     // Link via RoleId
                .OnDelete(DeleteBehavior.Cascade);  // When Role is deleted, delete RolePermissions

            // Define relationship: One Permission can belong to many RolePermissions
            builder.HasOne(rp => rp.Permission)     // Each RolePermission has one Permission
                .WithMany(p => p.RolePermissions)    // Each Permission can have many RolePermissions
                .HasForeignKey(rp => rp.PermissionId) // Link via PermissionId
                .OnDelete(DeleteBehavior.Cascade);   // When Permission is deleted, delete RolePermissions
            // Optional: specify table name explicitly
            builder.ToTable("RolePermissions");
        }
    }
}
