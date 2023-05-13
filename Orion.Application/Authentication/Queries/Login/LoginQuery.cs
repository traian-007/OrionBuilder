using ErrorOr;
using MediatR;
using Orion.Application.Authentication.Common;

namespace Orion.Application.Authentication.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
