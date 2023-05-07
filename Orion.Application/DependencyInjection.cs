using Microsoft.Extensions.DependencyInjection;
using Orion.Application.Services.Authentication;

namespace Orion.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
