using UberEats.Domain.Entities;

namespace UberEats.Application.Services.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token);
}
