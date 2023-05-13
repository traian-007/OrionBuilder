using ErrorOr;
using MediatR;
using Orion.Application.Authentication.Common;

namespace Orion.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
         string FirstName,
         string LastName,
         string Email,
         string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
