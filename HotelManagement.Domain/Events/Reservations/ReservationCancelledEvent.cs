using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Reservation
{
    public sealed class ReservationCancelledEvent : IDomainEvent
    {
        public Guid ReservationId { get; }

        public ReservationCancelledEvent(Guid reservationId)
        {
            ReservationId = reservationId;
        }
    }
}
