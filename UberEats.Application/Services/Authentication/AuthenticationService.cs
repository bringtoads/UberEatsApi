using ErrorOr;
using UberEats.Application.Common.Errors;
using UberEats.Application.Common.Interfaces.Authentication;
using UberEats.Application.Common.Interfaces.Persistence;
using UberEats.Domain.Common.Errors;
using UberEats.Domain.Entities;

namespace UberEats.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenrator;
        private readonly IUserRepository _userRepository;
        public AuthenticationService(IJwtTokenGenerator jwtTokenGenrator, IUserRepository userRepository)
        {
            _jwtTokenGenrator = jwtTokenGenrator;
            _userRepository = userRepository;
        }

        public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
        {
            //1. Check if user already exists  (Validate user doesn't exist)
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                //return new AuthenticationResult(false, "User already exists");
                //(this is not a good way)throw new Exception("User with given email already aexists"); 
                //do this instead
                //throw new DuplicateEmailException();
                //return Result.Fail<AuthenticationResult>(new[] { new DuplicateEmailError() });
                return Errors.User.DuplicateEmail;
            }

            //2. Create user (generate unique Id) and add to db
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
            _userRepository.Add(user);

            //3. Create JWT token
            var token = _jwtTokenGenrator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
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
