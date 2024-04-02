using ErrorOr;
using MediatR;
using UberEats.Application.Common.Interfaces.Authentication;
using UberEats.Application.Common.Interfaces.Persistence;
using UberEats.Domain.Entities;
using UberEats.Domain.Common.Errors;
using UberEats.Application.Authentication.Queries.Login;
using UberEats.Application.Authentication.Common;

namespace UberEats.Application.Authentication.Commands.Login
{
    public class LoginQueryHandler :
        IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenrator;
        private readonly IUserRepository _userRepository;
        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenrator, IUserRepository userRepository)
        {
            _jwtTokenGenrator = jwtTokenGenrator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            //1.Validate if user exists
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            //2. Validate the password is correct.
            if (user.Password != query.Password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            //3. Create jwt token
            var token = _jwtTokenGenrator.GenerateToken(user);
            return new AuthenticationResult(
                user,
                token);
        }
    }
}
