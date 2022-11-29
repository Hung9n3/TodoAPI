using Contracts.DataProviders;
using Contracts.ProcessingProviders;
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
using TodoApi.DataProviders;

namespace TodoApi.ProcessingProvider.Extensions
{
    public static class ProcessingServiceCollectionExtension
    {
        public static void AddProcessingService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddProcessingService();
        }
        public static void AddProcessingService(this IServiceCollection services)
        {
           services.AddScoped<IWorkProcessingProvider, WorkProcessingProvider>();
        }
    }
}
