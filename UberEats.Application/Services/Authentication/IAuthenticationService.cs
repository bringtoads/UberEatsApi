using ErrorOr;

namespace UberEats.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        //AuthenticationResult Register(string  firstName,string lastName, string email, string password);
        ErrorOr<AuthenticationResult> Register(string  firstName,string lastName, string email, string password);
        ErrorOr<AuthenticationResult> Login(string email, string password);
    }
}
