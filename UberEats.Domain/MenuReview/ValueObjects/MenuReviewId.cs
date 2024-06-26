﻿using UberEats.Domain.Common.Models;

namespace UberEats.Domain.MenuReview.ValueObjects
{
    public sealed class MenuReviewId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        public MenuReviewId(Guid value)
        {
            Value = value;
        }

        public static MenuReviewId CreateUnique()
        {
            return new MenuReviewId(Guid.NewGuid());
        }

        public static MenuReviewId Create(Guid value)
        {
            return new(value);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        private MenuReviewId()
        {
            
        }
    }
}
