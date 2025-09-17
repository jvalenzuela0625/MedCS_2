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
    public class PermissionsConfig : IEntityTypeConfiguration<Permissions>
    {
        public void Configure(EntityTypeBuilder<Permissions> builder)
        {
            builder.HasKey(p => p.Id); // Primary key from BaseEntity<Guid>

            builder.Property(p => p.Endpoint)
                   .HasMaxLength(255);

            builder.Property(p => p.Module)
                   .HasMaxLength(100);

            builder.HasIndex(p => new { p.Endpoint, p.Module }).IsUnique(); // No duplicate endpoint/type pair

            builder.ToTable("Permissions");
        }
    }
}
