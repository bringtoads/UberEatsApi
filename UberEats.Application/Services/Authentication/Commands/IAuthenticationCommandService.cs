using ErrorOr;
using UberEats.Application.Services.Authentication.Common;

namespace UberEats.Application.Services.Authentication.Commands
{
    public interface IAuthenticationCommandService
    {
        //AuthenticationResult Register(string  firstName,string lastName, string email, string password);
        ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
    }
}
