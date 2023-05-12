using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orion.Application.Common.Interfaces.Authentication;
using Orion.Application.Common.Interfaces.Persistence;
using Orion.Application.Common.Interfaces.Services;
using Orion.Infrastructure.Authentication;
using Orion.Infrastructure.Persistence;
using Orion.Infrastructure.Services;

namespace Orion.Ifrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
