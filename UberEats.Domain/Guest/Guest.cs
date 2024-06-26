﻿using UberEats.Domain.Common.Models;
using UberEats.Domain.Guest.ValuObjects;

namespace UberEats.Domain.Guest
{
    public sealed class Guest : AggregateRoot<GuestId,Guid>
    {
        public Guest(GuestId id) : base(id)
        {
            
        }
#pragma warning disable CS8618
        private Guest() { }
#pragma warning restore CS8618
    }
}
