using UberEats.Domain.Common.Models;
using UberEats.Domain.Common.ValueObjects;
using UberEats.Domain.Dinner.ValueObjects;
using UberEats.Domain.Host.ValueObjects;
using UberEats.Domain.Menus.Entities;
using UberEats.Domain.Menus.Events;
using UberEats.Domain.Menus.ValueObjects;
using UberEats.Domain.MenuReview.ValueObjects;

namespace UberEats.Domain.Menus
{
    public sealed class Menu : AggregateRoot<MenuId,Guid>
    {
        private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinnerIds = new();
        private readonly List<MenuReviewId> _menuRevieIds = new();
        public string Name { get; }
        public string Description { get; }
        public AverageRating AverageRating { get; }

        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
        public HostId HostId { get; private set; }
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIDs=> _menuRevieIds.AsReadOnly();
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        private Menu(
            MenuId menuId,
            HostId hostId,
            string name,
            string description,
            AverageRating averageRating,
            List<MenuSection>? sections) : base(menuId)
        {
            HostId = hostId;
            Name = name;
            Description = description;
            _sections = sections;
            AverageRating = averageRating;

        }
        public static Menu Create(
            HostId hostId,
            string name,
            string description,
            List<MenuSection>? sections =null)
        {
            var menu =  new Menu(MenuId.CreateUnique(), hostId, name, description,AverageRating.CreateNew(0),
                sections?? new());
            menu.AddDomainEvent(new MenuCreated(menu));

            return menu;
        }
#pragma warning disable CS8618
        private Menu() { }
#pragma warning restore CS8618
    }
}
