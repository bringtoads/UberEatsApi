using ErrorOr;
using MediatR;
using UberEats.Application.Authentication.Common;

namespace UberEats.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password): IRequest<ErrorOr<AuthenticationResult>>;
}
