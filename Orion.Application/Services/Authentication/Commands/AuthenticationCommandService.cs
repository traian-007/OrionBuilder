using ErrorOr;
using Orion.Application.Common.Interfaces.Authentication;
using Orion.Application.Common.Interfaces.Persistence;
using Orion.Application.Services.Authentication.Common;
using Orion.Domain.Common.Errors;
using Orion.Domain.Entities;

namespace Orion.Application.Services.Authentication.Commands
{
    public class AuthenticationCommandService : IAuthenticationCommandService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
        {
            // 1. Validate the user doesn't exist
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                return Errors.User.DuplicateEmail;
                //throw new Exception("User with given email already exist!");
            }

            // 2. Create user (generate a unique ID) & Persist to DB
            var user = new UserEntity
            {
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

    }
}
