using BusinessLayer.Contracts;
using BusinessLayer.Services;
using DataAccessLayer.Caching;
using DataAccessLayer.Contracts;
using Enyim.Caching.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace BusinessLayer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataLayer(this IServiceCollection services, List<Server> servers)
        {
            services.AddEnyimMemcached(o => o.Servers = servers);
        }
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddSingleton<ICacheRepository, CacheRepository>();
        }       

    }
}
