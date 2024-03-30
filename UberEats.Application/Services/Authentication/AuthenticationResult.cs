using UberEats.Domain.Entities;

namespace UberEats.Application.Services.Authentication
{
    public record AuthenticationResult(
        User User,
        string Token);
}
