﻿using UberEats.Domain.Common.Models;

namespace UberEats.Domain.Bill.ValueObjects
{
    public sealed class BillId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        public BillId(Guid value )
        {
            Value = value;
        }

        public static BillId CreateUnique() 
        {
            return new(Guid.NewGuid());
        }

        public static BillId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqalityComponenets()
        {
            yield retrun Value;
        }
    }
}
