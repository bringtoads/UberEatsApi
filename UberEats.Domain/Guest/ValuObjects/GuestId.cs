using UberEats.Domain.Common.Models;

namespace UberEats.Domain.Guest.ValuObjects
{
    public sealed class GuestId : AggregateRootId<Guid>
    {
        public override Guid Value { get ; protected set; }

        private GuestId(Guid value)
        {
            Value = value;
        }

        public static GuestId CreateUnqiue()
        {
            return new(Guid.NewGuid());
        }

        public static GuestId Create(Guid value)
        {
            return new(value);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
