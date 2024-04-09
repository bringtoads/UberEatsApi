using UberEats.Domain.Common.Models;
using UberEats.Domain.Menu.ValueObjects;

namespace UberEats.Domain.Menu.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();
        public string Name { get; }
        public string Description { get; }

        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        private MenuSection(MenuSectionId menuSetionId, string name, string description) : base(menuSetionId)
        {
            Name = name;
            Description = description;
        }

        public static MenuSection Create(string name, string description)
        {
            return new(MenuSectionId.CreateUnique(),name,description);
        }
    }
}
