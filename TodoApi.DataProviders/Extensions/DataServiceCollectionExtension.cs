using Contracts.DataProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Core.Database;
using TodoApi.Core.Entities;

namespace TodoApi.DataProviders.Extensions
{
    public static class DataServiceCollectionExtension
    {
        public static void AddDataService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataService();
        }
        public static void AddDataService(this IServiceCollection services)
        {
            services.AddScoped<IWorkDataProvider, WorkDataProvider>();
        }
    }
}
