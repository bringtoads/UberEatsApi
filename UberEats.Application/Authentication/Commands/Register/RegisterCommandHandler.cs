using ErrorOr;
using MediatR;
using UberEats.Application.Common.Interfaces.Authentication;
using UberEats.Application.Common.Interfaces.Persistence;
using UberEats.Domain.Entities;
using UberEats.Domain.Common.Errors;
using UberEats.Application.Authentication.Common;

namespace UberEats.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler :
        IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenrator;
        private readonly IUserRepository _userRepository;
        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenrator, IUserRepository userRepository)
        {
            _jwtTokenGenrator = jwtTokenGenrator;
            _userRepository = userRepository;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            //1. Check if user already exists  (Validate user doesn't exist)
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            //2. Create user (generate unique Id) and add to db
            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password
            };
            _userRepository.Add(user);

            //3. Create JWT token
            var token = _jwtTokenGenrator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
