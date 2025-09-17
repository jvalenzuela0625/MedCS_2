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
    public class RolesConfig : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            // Set primary key (inherited from BaseEntity<int>)
            builder.HasKey(r => r.Id);            
            builder.Property(r => r.Name)                
                .HasMaxLength(200); 

            // Ensure role names are unique
            builder.HasIndex(r => r.Name).IsUnique(); 

            // Optional: specify table name explicitly
            builder.ToTable("Roles");
        }
    }
}
