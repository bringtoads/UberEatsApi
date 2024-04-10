using UberEats.Domain.Common.Models;

namespace UberEats.Domain.User.ValueObjects
{
    public class UserId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        public UserId(Guid value)
        {
            Value = value;
        }
        public static UserId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static UserId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
