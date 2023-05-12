using Orion.Domain.Entities;

namespace Orion.Application.Services.Authentication
{
    public record AuthenticationResult(
        User User,
        string Token);
}
