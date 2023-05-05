using CLINICAL.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;

namespace CLINICAL.Persistence.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionPersistencia(this IServiceCollection services)
        {

            services.AddSingleton<ApplicationDbContext>();

            return services;
        }
    }
}
