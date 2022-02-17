using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MovieStore.Mappings
{
    public static class MappingService
    {
        public static IServiceCollection AddMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
