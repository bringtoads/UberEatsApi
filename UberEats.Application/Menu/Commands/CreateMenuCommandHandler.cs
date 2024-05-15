using ErrorOr;
using MediatR;
using UberEats.Application.Common.Interfaces.Persistence;
using UberEats.Domain.Host.ValueObjects;
using UberEats.Domain.Menus.Entities;

namespace UberEats.Application.Menu.Commands
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Domain.Menus.Menu>>
    {
        // need to inject menu repo here;
        private readonly IMenuRepository _menuRepository;
        public CreateMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        public async Task<ErrorOr<Domain.Menus.Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var menu = Domain.Menus.Menu.Create(
                hostId: HostId.Create(request.HostId),
                name: request.Name,
                description: request.Description,
                sections: request.Sections.ConvertAll(sections => MenuSection.Create(
                    name: sections.Name,
                    description: sections.Descriptioin,
                    items: sections.Items.ConvertAll(items => MenuItem.Create(
                        name: items.Name,
                        description: items.Description)))));
            // add in repo
            _menuRepository.Add(menu);
            return menu;
        }
    }
}
