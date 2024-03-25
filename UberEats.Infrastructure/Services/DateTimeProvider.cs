using UberEats.Application.Common.Interfaces.Services;

namespace UberEats.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
