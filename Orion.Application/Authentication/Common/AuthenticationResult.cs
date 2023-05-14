using Orion.Domain.Entities;

namespace Orion.Application.Authentication.Common
{
    public record AuthenticationResult(
        UserEntity User,
        string Token);
}
