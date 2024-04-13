using UberEats.Domain.User;
namespace UberEats.Application.Authentication.Common
{
    public record AuthenticationResult(
          User User,
          string Token);
}
