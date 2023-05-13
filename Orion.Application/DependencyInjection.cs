using Microsoft.Extensions.DependencyInjection;
using Orion.Application.Services.Authentication.Commands;
using Orion.Application.Services.Authentication.Queries;

namespace Orion.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
            services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();

            return services;
        }
    }
}
