using UberEats.Domain.Common.Models;
using UberEats.Domain.Guest.ValuObjects;

namespace UberEats.Domain.Guest
{
    public sealed class Guest : AggregateRoot<GuestId,Guid>
    {
        public Guest(GuestId id) : base(id)
        {
            
        }
    }
}
