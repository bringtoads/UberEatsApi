﻿using UberEats.Domain.Bill.ValueObjects;
using UberEats.Domain.Common.Models;
using UberEats.Domain.Dinner.ValueObjects;
using UberEats.Domain.Guest.ValuObjects;
using UberEats.Domain.Host.ValueObjects;

namespace UberEats.Domain.Bill
{
    public sealed class Bill: AggregateRoot<BillId,Guid>
    {
        public DinnerId DinnerId { get; }
        public GuestId GuestId { get; }
        public HostId HostId { get; }
        public Price Price { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdateDateTime { get; }

        private Bill(BillId id, GuestId guestId, HostId hostId, Price price,DateTime createdDate, DateTime updatedDate) : base(id)
        {
            GuestId = guestId;
            HostId = hostId;
            Price 
        }
    }
}
