using MedCS_2.Presistence.DbContext;
using MedCS_2.Presistence.Repositories.Requests;
using MedCS_2.Presistence.Repositories.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MedCS_2.Presistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var dbProvider = configuration["Database:Provider"];
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if(dbProvider == "SqlServer")
            {
                services.AddDbContext<MedCSAppDbContext>(options =>
                    options.UseSqlServer(connectionString));
            }

            //Application module repository service registration.
            services.AddSecurityRepositories();
            services.AddRequestRepositories();

            return services;
        }
    }
}