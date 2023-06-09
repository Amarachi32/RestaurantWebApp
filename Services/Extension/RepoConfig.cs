using Contracts.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Extension
{
    public static class RepoConfig
    {
        public static void ConfigureRepo(this IServiceCollection service)
        {
            service.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }

}
