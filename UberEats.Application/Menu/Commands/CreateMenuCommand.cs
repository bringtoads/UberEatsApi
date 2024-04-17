using ErrorOr;
using MediatR;

namespace UberEats.Application.Menu.Commands
{
    public record CreateMenuCommand(
        Guid HostId,
        string Name,
        string Description,
        List<MenuSectionCommand> Sections) : IRequest<ErrorOr<Domain.Menus.Menu>>;
    public record MenuSectionCommand(
        string Name,
        string Descriptioin,
        List<MenuItemCommand> Items);
    public record MenuItemCommand(
        string Name,
        string Description);

}
