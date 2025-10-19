using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Reservation
{
    public sealed class ReservationConfirmedEvent : IDomainEvent
    {
        public Guid ReservationId { get; }

        public ReservationConfirmedEvent(Guid reservationId)
        {
            ReservationId = reservationId;
        }
    }
}
