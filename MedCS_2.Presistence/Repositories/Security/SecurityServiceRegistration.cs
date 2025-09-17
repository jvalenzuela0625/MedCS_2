using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Presistence.Repositories.Security
{
    public static partial class SecurityServiceRegistration
    {
        public static IServiceCollection AddSecurityRepositories(this IServiceCollection services)
        {
            services.AddScoped<Interfaces.IUserRolesRepository, UserRolesRepository>();
            services.AddScoped<Interfaces.IRolesRepository, RolesRepository>();
            services.AddScoped<Interfaces.IRolePermissionsRepository, RolePermissionsRepository>();
            services.AddScoped<Interfaces.IPermissionsRepository, PermissionsRepository>();
            return services;
        }
    }
}
