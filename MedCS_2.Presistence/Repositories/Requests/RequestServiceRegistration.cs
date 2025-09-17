using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Presistence.Repositories.Requests
{
    public static partial class RequestServiceRegistration
    {
        public static IServiceCollection AddRequestRepositories(this IServiceCollection services)
        {
            return services;
        }
    }
}
