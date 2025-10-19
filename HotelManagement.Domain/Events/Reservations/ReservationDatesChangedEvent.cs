using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Reservation
{
    public sealed class ReservationDatesChangedEvent : IDomainEvent
    {
        public Guid ReservationId { get; }
        public DateTime NewCheckIn { get; }
        public DateTime NewCheckOut { get; }

        public ReservationDatesChangedEvent(Guid reservationId, DateTime newCheckIn, DateTime newCheckOut)
        {
            ReservationId = reservationId;
            NewCheckIn = newCheckIn;
            NewCheckOut = newCheckOut;
        }
    }
}
