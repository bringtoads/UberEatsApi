using ErrorOr;
using UberEats.Application.Services.Authentication.Common;

namespace UberEats.Application.Services.Authentication.Queries
{
    public interface IAuthenticationQueryService
    {
        ErrorOr<AuthenticationResult> Login(string email, string password);
    }
}
