using ErrorOr;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Orion.API.Controllers;
using Orion.Application.Common.Errors;
using Orion.Application.Services.Authentication;
using Orion.Contracts.Authentication;

namespace Orion.API.Controlles
{
    [Route("auth")]
    // [ErrorHandlingFilter]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            ErrorOr<AuthenticationResult> registerResult = _authenticationService.Register(
                request.FirstName, 
                request.LastName, 
                request.Email, 
                request.Password);

            return registerResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));
        }


        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            ErrorOr<AuthenticationResult> authResult = _authenticationService.Login(
               request.Email,
               request.Password);

            if(authResult.IsError && authResult.FirstError == Domain.Common.Errors.Errors.Authentication.InvalidCredentials)
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
