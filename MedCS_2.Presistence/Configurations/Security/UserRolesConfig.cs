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
    /// <summary>
    /// Entity Framework Core configuration for the UserRoles join entity.
    /// Represents the many-to-many relationship between Users and Roles.
    /// </summary>
    public class UserRolesConfig : IEntityTypeConfiguration<UserRoles>
    {
        public void Configure(EntityTypeBuilder<UserRoles> builder)
        {
            // Set primary key (inherited from BaseEntity<Guid>)
            builder.HasKey(ur => ur.Id);
            // Configure foreign key to Users
            builder.Property(ur => ur.UserId).IsRequired();
            // Configure foreign key to Roles
            builder.Property(ur => ur.RoleId).IsRequired();

            // Define relationship: One User has many UserRoles
            builder.HasOne(ur => ur.User)           // Each UserRole has one User
                .WithMany(u => u.UserRoles)         // Each User has many UserRoles
                .HasForeignKey(ur => ur.UserId)     // Link via UserId
                .OnDelete(DeleteBehavior.Cascade);  // When User is deleted, delete UserRoles

            // Define relationship: One Role has many UserRoles
            builder.HasOne(ur => ur.Role)           // Each UserRole has one Role
                .WithMany(r => r.UserRoles)         // Each Role has many UserRoles
                .HasForeignKey(r => r.RoleId)       // Link via RoleId
                .OnDelete(DeleteBehavior.Cascade);  // When Role is deleted, delete UserRoles

            // Optional: Ensure a user cannot have the same role twice
            builder.HasIndex(ur => new { ur.UserId, ur.RoleId }).IsUnique();

            // Optional: specify table name explicitly
            builder.ToTable("UserRoles");
        }
    }
}
