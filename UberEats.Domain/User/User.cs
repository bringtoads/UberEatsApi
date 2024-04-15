using UberEats.Domain.Common.Models;
using UberEats.Domain.User.ValueObjects;

namespace UberEats.Domain.User
{
    public sealed class User : AggregateRoot<UserId,Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        private User(
            UserId id,
            string firstName,
            string lastName,
            string email,
            string password,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static User Create(
            string firstName,
            string lastName,
            string email,
            string password)
        {
            return new(
                UserId.CreateUnique(),
                firstName,
                lastName,
                email,
                password,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
#pragma warning disable CS8618
        private User() { }
#pragma warning restore CS8618
    }
}
