using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Hotels
{
    public sealed class RoomAddedEvent : IDomainEvent
    {
        public Guid HotelId { get; }
        public Guid RoomId { get; }
        public RoomAddedEvent(Guid hotelId, Guid roomId)
        {
            HotelId = hotelId;
            RoomId = roomId;
        }
    }
}
