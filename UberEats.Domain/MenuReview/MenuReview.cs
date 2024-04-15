﻿using UberEats.Domain.Common.Models;
using UberEats.Domain.Common.ValueObjects;
using UberEats.Domain.Dinner.ValueObjects;
using UberEats.Domain.Guest.ValuObjects;
using UberEats.Domain.Host.ValueObjects;
using UberEats.Domain.Menu.ValueObjects;
using UberEats.Domain.MenuReview.ValueObjects;

namespace UberEats.Domain.MenuReview
{
    public sealed class MenuReview : AggregateRoot<MenuReviewId,Guid>
    {
        public Rating Rating { get; }
        public string Comment { get; }
        public HostId HostId { get; }
        public MenuId MenuId { get; }
        public GuestId GuestId { get; }
        public DinnerId DinnerId { get; }
        public DateTime CreatedDateTime { get;  }
        public DateTime UpdatedDateTime { get; }
        public MenuReview(
            MenuReviewId menuReviewId,
            string comment,
            HostId hostId,
            MenuId menuId,
            GuestId guestId,
            DinnerId dinnerId,
            DateTime createdDateTime,
            DateTime updatedDateTime) 
            : base(menuReviewId)
        {
            Comment = comment;
            HostId = hostId;
            MenuId = menuId;
            GuestId = guestId;
            DinnerId = dinnerId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }
        public static MenuReview Create(string comment, HostId hostId, MenuId menuId, GuestId guestId, DinnerId dinnerId)
        {
            return new(MenuReviewId.CreateUnique(), comment, hostId, menuId, guestId, dinnerId, DateTime.UtcNow, DateTime.UtcNow);
        }
#pragma warning disable CS8618
        private MenuReview() { }
#pragma warning restore CS8618
    }
}
