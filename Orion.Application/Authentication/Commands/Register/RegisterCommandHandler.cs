using ErrorOr;
using MediatR;
using Orion.Application.Authentication.Common;
using Orion.Application.Common.Interfaces.Authentication;
using Orion.Application.Common.Interfaces.Persistence;
using Orion.Domain.Common.Errors;
using Orion.Domain.Entities;

namespace Orion.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : 
        IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            // 1. Validate the user doesn't exist
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
                //throw new Exception("User with given email already exist!");
            }

            // 2. Create user (generate a unique ID) & Persist to DB
            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password
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
