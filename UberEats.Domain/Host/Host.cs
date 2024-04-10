using UberEats.Domain.Common.Models;
using UberEats.Domain.Common.ValueObjects;
using UberEats.Domain.Dinner.ValueObjects;
using UberEats.Domain.Host.ValueObjects;
using UberEats.Domain.Menu.ValueObjects;
using UberEats.Domain.User.ValueObjects;

namespace UberEats.Domain.Host
{
    public sealed class Host : AggregateRoot<HostId,Guid>
    {
        private readonly List<MenuId> _menuIds = new();
        private readonly List<DinnerId> _dinnerIds = new();

        public string FirstName { get; }
        public string LastName { get; }
        public string ProfileImage { get; }
        public AverageRating AverageRating { get; }
        public UserId UserId { get; }

        public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        public Host(HostId hostId, string firstName, string lastName, string profileImage, AverageRating averageRating, UserId userId, DateTime createdDateTime, DateTime updatedDateTime) : base(hostId)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            AverageRating = averageRating;
            UserId = userId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Host Create(
            string firstName, 
            string lastName, 
            string profileImage,
            AverageRating averageRating,
            UserId userId)
        {
            return new(
                HostId.CreateUnique(),
                firstName,
                lastName,
                profileImage,
                averageRating,
                userId,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}
