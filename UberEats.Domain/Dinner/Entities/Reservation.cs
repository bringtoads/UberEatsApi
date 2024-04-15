using UberEats.Domain.Bill.ValueObjects;
using UberEats.Domain.Common.Models;
using UberEats.Domain.Dinner.ValueObjects;
using UberEats.Domain.Guest.ValuObjects;

namespace UberEats.Domain.Dinner.Entities
{
    public sealed class Reservation : Entity<ReservationId>
    {
        public int Guestcount { get; }
        public string ReservationStatus { get; }
        public GuestId GuestId { get; }
        public BillId BillId { get; }
        public DateTime? ArrivalDateTime { get; private set; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }
      
        private Reservation(ReservationId reservationId, int guestCount, string reservationStatus, GuestId guestId, BillId billId, DateTime createdDateTime, DateTime updatedDateTime) : base(reservationId)
        {
            Guestcount = guestCount;
            ReservationStatus = reservationStatus;
            GuestId = guestId;
            BillId = billId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }
        public static Reservation Create(
          int guestCount,
          string reservatiionStatus,
          GuestId guestId,
          BillId billId)
        {
            return new(
                ReservationId.CreateUnique(),
                guestCount,
                reservatiionStatus,
                guestId,
                billId,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
#pragma warning disable CS8618
        private Reservation() { }
#pragma warning restore CS8618
    }
}
