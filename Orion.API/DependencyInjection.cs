using Microsoft.AspNetCore.Mvc.Infrastructure;
using Orion.API.Common.Errors;
using Orion.API.Common.Mapping;

namespace Orion.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<ProblemDetailsFactory, OrionProblemDetailsFactory>();

            services.AddMappings();

            return services;
        }
    }
}
