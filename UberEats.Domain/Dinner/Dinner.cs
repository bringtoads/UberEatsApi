﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEats.Domain.Bill.ValueObjects;
using UberEats.Domain.Common.Models;
using UberEats.Domain.Dinner.Entities;
using UberEats.Domain.Dinner.ValueObjects;
using UberEats.Domain.Host.ValueObjects;
using UberEats.Domain.Menus.ValueObjects;

namespace UberEats.Domain.Dinner
{
    public sealed class Dinner : AggregateRoot<DinnerId, Guid>
    {
        private readonly List<Reservation> _resevations = new();

        public string Name { get; }
        public string Description { get; }
        public DateTime StartDateTime { get; }
        public DateTime EndDateTime { get; }
        public DateTime? StartedDateTime { get; }
        public DateTime? EndedDateTime { get; }
        public string Status { get; }
        public bool IsPublic { get; }
        public int MaxGuests { get; }
        public Price Price { get; }
        public HostId HostId { get; }
        public MenuId MenuId { get; }
        public string ImageUrl { get; }
        public Location Location { get; }

        public IReadOnlyList<Reservation> Reservations => _resevations.AsReadOnly();

        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Dinner(
            DinnerId id,
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            string status,
            bool isPublic,
            int maxGuests,
            Price price,
            HostId hostId,
            MenuId menuId,
            string imageUrl,
            Location location,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(id)
        {
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Status = status;
            IsPublic = isPublic;
            MaxGuests = maxGuests;
            Price = price;
            HostId = hostId;
            MenuId = menuId;
            ImageUrl = imageUrl;
            Location = location;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Dinner Create(
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            string status,
            bool isPublic,
            int maxGuests,
            Price price,
            HostId hostId,
            MenuId menuId,
            string imageUrl,
            Location location)
        {
            return new(DinnerId.CreateUnique(),name,description,startDateTime,endDateTime,status, isPublic, maxGuests, price, hostId, menuId,imageUrl,location,DateTime.UtcNow,DateTime.UtcNow);
        }
#pragma warning disable CS8618
        private Dinner() { }
#pragma warning restore CS8618
    }

}
