using Orion.Domain.Entities;

namespace Orion.Application.Services.Authentication.Common
{
    public record AuthenticationResult(
        UserEntity User,
        string Token);
}
