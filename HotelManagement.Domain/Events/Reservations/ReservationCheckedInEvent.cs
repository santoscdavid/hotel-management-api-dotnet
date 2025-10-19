using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Reservation
{
    public sealed class ReservationCheckedInEvent : IDomainEvent
    {
        public Guid ReservationId { get; }
        public DateTime CheckedInAt { get; }

        public ReservationCheckedInEvent(Guid reservationId, DateTime checkedInAt)
        {
            ReservationId = reservationId;
            CheckedInAt = checkedInAt;
        }
    }
}
