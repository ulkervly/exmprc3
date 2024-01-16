using Hook.Core.Repositories;
using Hook.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hook.Data.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IFeatureRepository,FeatureRepository>();
        }
    }
}
