using Hook.Business.Services.Implementations;
using Hook.Business.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hook.Business.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static  void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IFeatureService , FeatureService>();
        }

    }
}
