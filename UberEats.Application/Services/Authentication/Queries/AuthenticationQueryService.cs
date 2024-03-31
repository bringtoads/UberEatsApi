using ErrorOr;
using UberEats.Application.Common.Errors;
using UberEats.Application.Common.Interfaces.Authentication;
using UberEats.Application.Common.Interfaces.Persistence;
using UberEats.Application.Services.Authentication.Common;
using UberEats.Domain.Common.Errors;
using UberEats.Domain.Entities;

namespace UberEats.Application.Services.Authentication.Queries
{
    public class AuthenticationQueryService : IAuthenticationQueryService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenrator;
        private readonly IUserRepository _userRepository;
        public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenrator, IUserRepository userRepository)
        {
            _jwtTokenGenrator = jwtTokenGenrator;
            _userRepository = userRepository;
        }
        public ErrorOr<AuthenticationResult> Login(string email, string password)
        {
            //1.Validate if user exists
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            //2. Validate the password is correct.
            if (user.Password != password)
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
