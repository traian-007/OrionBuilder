﻿using ErrorOr;
using Orion.Application.Common.Interfaces.Authentication;
using Orion.Application.Common.Interfaces.Persistence;
using Orion.Application.Services.Authentication.Common;
using Orion.Domain.Common.Errors;
using Orion.Domain.Entities;

namespace Orion.Application.Services.Authentication.Queries
{
    public class AuthenticationQueryService : IAuthenticationQueryService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public ErrorOr<AuthenticationResult> Login(string email, string password)
        {
            // 1. Validation the user exists
            if (_userRepository.GetUserByEmail(email) is not UserEntity user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // 2. Validate the password is correct
            if (user.Password != password)
            {
                return new[] { Errors.Authentication.InvalidCredentials };
            }

            // 3. Create JWT token

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
