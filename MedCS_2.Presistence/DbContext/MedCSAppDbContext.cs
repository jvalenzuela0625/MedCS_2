using MedCS_2.Domain.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Presistence.DbContext
{    
    public class MedCSAppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {        
        public MedCSAppDbContext(DbContextOptions<MedCSAppDbContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<RolePermissions> RolePermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(typeof(MedCSAppDbContext).Assembly);
           base.OnModelCreating(modelBuilder);
        }
    }
}
