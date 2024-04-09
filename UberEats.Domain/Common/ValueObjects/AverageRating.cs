using UberEats.Domain.Common.Models;

namespace UberEats.Domain.Common.ValueObjects
{
    public sealed class AverageRating : ValueObject
    {
        public double Value { get; private set; }
        public int NumRatings { get; private set; }
        public AverageRating()
        {
            
        }
    }
}
