using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Reservation
{
    public sealed class ReservationCheckedOutEvent : IDomainEvent
    {
        public Guid ReservationId { get; }
        public DateTime CheckedOutAt { get; }

        public ReservationCheckedOutEvent(Guid reservationId, DateTime checkedOutAt)
        {
            ReservationId = reservationId;
            CheckedOutAt = checkedOutAt;
        }
    }
}
