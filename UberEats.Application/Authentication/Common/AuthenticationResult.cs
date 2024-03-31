using UberEats.Domain.Entities;
namespace UberEats.Application.Authentication.Common
{
    public record AuthenticationResult(
          User User,
          string Token);
}
