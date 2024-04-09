﻿using UberEats.Domain.Common.Models;

namespace UberEats.Domain.Menu.ValueObjects
{
    public sealed class MenuSectionId : ValueObject
    {
        public Guid Value { get; }
        private MenuSectionId(Guid value)
        {
            Value = value;
        }

        public static MenuSectionId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
