﻿using OneOf;
using Orion.Application.Common.Errors;
using Orion.Application.Common.Interfaces.Authentication;
using Orion.Application.Common.Interfaces.Persistence;
using Orion.Domain.Entities;

namespace Orion.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public OneOf<AuthenticationResult, IError> Register(string firstName, string lastName, string email, string password)
        {
            // 1. Validate the user doesn't exist
            if(_userRepository.GetUserByEmail(email) is not null)
            {
                return new DuplicateEmailError();
                //throw new Exception("User with given email already exist!");
            }

            // 2. Create user (generate a unique ID) & Persist to DB
            var user = new User { 
                FirstName = firstName, 
                LastName = lastName, 
                Email = email, 
                Password = password 
            };

            _userRepository.Add(user);

            // 3. Create JWT token

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }

        public AuthenticationResult Login(string email, string password)
        {
            // 1. Validation the user exists
            if(_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User with given email does not exist!");
            }

            // 2. Validate the password is correct
            if (user.Password != password)
            {
                throw new Exception("Invalid password");
            }

            // 3. Create JWT token

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
