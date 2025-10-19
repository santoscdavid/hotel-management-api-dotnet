using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Reservation
{
    public sealed class ReservationPriceChangedEvent : IDomainEvent
    {
        public Guid ReservationId { get; }
        public decimal NewPrice { get; }

        public ReservationPriceChangedEvent(Guid reservationId, decimal newPrice)
        {
            ReservationId = reservationId;
            NewPrice = newPrice;
        }

    }
}
