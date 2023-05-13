using Microsoft.Extensions.DependencyInjection;
using MediatR;


namespace Orion.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly));
            /*services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
            services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();*/

            return services;
        }
    }
}
