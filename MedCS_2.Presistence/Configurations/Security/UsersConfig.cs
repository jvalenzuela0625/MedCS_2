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
    public class UsersConfig : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.LastName).HasMaxLength(255);
            builder.Property(u => u.FirstName).HasMaxLength(255);
            builder.Property(u => u.Email).HasMaxLength(255).IsRequired();
            builder.Property(u => u.EntraId).HasMaxLength(255);
            builder.Property(u => u.JobTitle).HasMaxLength(255);
            builder.Property(u => u.Role).HasMaxLength(255);
            builder.Property(u => u.AccessToken).HasMaxLength(600);
            builder.Property(u => u.RefreshToken).HasMaxLength(255);
            builder.Property(u => u.Password).HasMaxLength(256);            
            builder.Property(u => u.IsActive);
            builder.Property(u => u.IsConnected);
            builder.Property(u => u.LastLogin);

            builder.ToTable("Users");
        }
    }
}
