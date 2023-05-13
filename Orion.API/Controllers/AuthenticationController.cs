using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Orion.API.Controllers;
using Orion.Application.Authentication.Commands.Register;
using Orion.Application.Authentication.Common;
using Orion.Application.Authentication.Queries.Login;
using Orion.Contracts.Authentication;

namespace Orion.API.Controlles
{
    [Route("auth")]
    // [ErrorHandlingFilter]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;

        public AuthenticationController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);

            ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(command);
            //ErrorOr<AuthenticationResult> registerResult = _authenticationCommandService.Register(


            return registerResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = new LoginQuery(request.Email, request.Password);
            //ErrorOr<AuthenticationResult> authResult = _authenticationQueryService.Login(

            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);

            if (authResult.IsError && authResult.FirstError == Domain.Common.Errors.Errors.Authentication.InvalidCredentials)
            {
                return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
            }

            return authResult.Match(
               authResult => Ok(MapAuthResult(authResult)),
               errors => Problem(errors));

        }

        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token);
        }
    }
}
