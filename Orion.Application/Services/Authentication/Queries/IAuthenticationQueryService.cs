using ErrorOr;
using Orion.Application.Services.Authentication.Common;

namespace Orion.Application.Services.Authentication.Queries
{
    public interface IAuthenticationQueryService
    {
        ErrorOr<AuthenticationResult> Login(string email, string password);
    }
}
