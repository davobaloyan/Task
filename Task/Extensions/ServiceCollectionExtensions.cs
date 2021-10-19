using Microsoft.Extensions.DependencyInjection;
using Task.MappingProfiles;

namespace Task.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMappingProfiles(this IServiceCollection services)
        {
            var mappingProfiles = new[]
            {
                typeof(CustomerProfile),
            };
            services.AddAutoMapper(mappingProfiles);

        }
    }
}
