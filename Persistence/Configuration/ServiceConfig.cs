using Microsoft.Extensions.DependencyInjection;
using Presentation.Implementation;
using Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public static class ServiceConfig
    {
        public static void ServiceConfigure(this IServiceCollection services) {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddTransient<IBraintreeService, BraintreeService>();
        }
    }
}
