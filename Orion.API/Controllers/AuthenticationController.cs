﻿using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orion.API.Controllers;
using Orion.Application.Authentication.Commands.Register;
using Orion.Application.Authentication.Common;
using Orion.Application.Authentication.Queries.Login;
using Orion.Contracts.Authentication;

namespace Orion.API.Controlles
{
    [Route("auth")]
    [AllowAnonymous]
    // [ErrorHandlingFilter]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
           // var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);

            ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(command);
            //ErrorOr<AuthenticationResult> registerResult = _authenticationCommandService.Register(


            return registerResult.Match(
                //authResult => Ok(MapAuthResult(authResult)),
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors));
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);
            //var query = new LoginQuery(request.Email, request.Password);
            //ErrorOr<AuthenticationResult> authResult = _authenticationQueryService.Login(

            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);

            if (authResult.IsError && authResult.FirstError == Domain.Common.Errors.Errors.Authentication.InvalidCredentials)
            {
                return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
            }

            return authResult.Match(
               //authResult => Ok(MapAuthResult(authResult)),
               authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
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
