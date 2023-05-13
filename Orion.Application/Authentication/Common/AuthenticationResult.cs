using Orion.Domain.Entities;

namespace Orion.Application.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token);
}
