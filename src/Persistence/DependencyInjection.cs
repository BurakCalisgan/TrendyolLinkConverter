using Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<TrendyolDbContext>();
            services.AddScoped<ITrendyolDbContext>(provider => provider.GetService<TrendyolDbContext>());
            return services;
        }
    }
}
