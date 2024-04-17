using UberEats.Domain.Common.Models;
using UberEats.Domain.Menus.ValueObjects;

namespace UberEats.Domain.Menus.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();
        public string Name { get; }
        public string Description { get; }

        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        private MenuSection(MenuSectionId menuSetionId, string name, string description, List<MenuItem> items) : base(menuSetionId)
        {
            Name = name;
            Description = description;
            _items = items;
        }

        public static MenuSection Create(string name, string description, List<MenuItem> items)
        {
            return new(MenuSectionId.CreateUnique(),name,description,items);
        }
    }
}
