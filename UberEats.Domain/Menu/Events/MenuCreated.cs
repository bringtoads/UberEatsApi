using UberEats.Domain.Common.Models;

namespace UberEats.Domain.Menu.Events
{
    public record MenuCreated(Menu menu) : IDomainEvent;
}
