using ErrorOr;
using MediatR;
using UberEats.Application.Authentication.Common;

namespace UberEats.Application.Authentication.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
