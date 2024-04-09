using UberEats.Domain.Common.Models;
using UberEats.Domain.Menu.Entities;
using UberEats.Domain.Menu.ValueObjects;

namespace UberEats.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinnerIds = new();
        private readonly List<MenuReviewId> _menuRevieIds = new();
 
        private readonly List<MenuSection> _sections = new();
        private readonly List<MenuItem> _item = new();


        public string Name { get; }
        public string Description { get; }
        public float AverageRating { get; }

        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
        public HostId HostId { get; }
        public IReadonlyList<MenuSection> DinnerIds => _dinnerIds.AsReadOnly();
        public IReadonlyList<MenuReviewId> MenuReviewIDs=> _menuRevieIds.AsReadOnly();
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }
        public Menu(
            MenuId menuId,
            string name,
            string description,
            HostId hostId,
            DateTime createdDateTime,
            DateTime updateDatetTime) : base(menuId)
        {
            Name = name;
            Description = description;
            HostId = hostId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;

        }
        public static Menu(
            string name,
            string description,
            HostId hostId)
        {
            retrun new(MenuId.CreateUnique(), name, description, hostId, DateTime.UtcNow, DateTime.UtcNow);
        }
    }
}
