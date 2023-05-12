﻿using OneOf;
using Orion.Application.Common.Errors;

namespace Orion.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResult Login(string email, string password);
        OneOf<AuthenticationResult, IError> Register(string firstName, string lastName, string email, string password);
    }
}
