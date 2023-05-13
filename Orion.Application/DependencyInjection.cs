using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Orion.Application.Authentication.Commands.Register;
using ErrorOr;
using Orion.Application.Authentication.Common;
using Orion.Application.Common.Behaviors;
using FluentValidation;
using System.Reflection;

namespace Orion.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly));
            services.AddScoped<
                IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>,
                ValidationRegisterCommandBehavior>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


            /*services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
            services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();*/

            return services;
        }
    }
}
