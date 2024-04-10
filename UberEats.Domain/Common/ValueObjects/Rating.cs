using UberEats.Domain.Common.Models;

namespace UberEats.Domain.Common.ValueObjects
{
    public sealed class Rating : ValueObject
    {
        public double Value { get; private set; }
        public Rating(double value)
        {
            Value = value;
        }

        public static Rating CreateNew(double value)
        {
            return new(value);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
