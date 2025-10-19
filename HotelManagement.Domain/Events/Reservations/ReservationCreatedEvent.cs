using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Reservation
{
    public sealed class ReservationCreatedEvent : IDomainEvent
    {
        public Guid Id { get; }
        public Guid RoomId { get; }
        public Guid GuestId { get; }
        public DateTime CheckIn { get; }
        public DateTime CheckOut { get; }

        public ReservationCreatedEvent(Guid id, Guid roomId, Guid guestId, DateTime checkIn, DateTime checkOut)
        {
            Id = id;
            RoomId = roomId;
            GuestId = guestId;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }
    }
}
