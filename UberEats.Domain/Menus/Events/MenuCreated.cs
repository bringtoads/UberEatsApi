using UberEats.Domain.Common.Models;

namespace UberEats.Domain.Menus.Events
{
    public record MenuCreated(Menu menu) : IDomainEvent;
}
