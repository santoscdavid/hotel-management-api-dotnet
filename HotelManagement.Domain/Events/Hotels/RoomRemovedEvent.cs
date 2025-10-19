using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Hotels
{
    public sealed class RoomRemovedEvent : IDomainEvent
    {
        public Guid HotelId { get; }
        public Guid RoomId { get; }
        public RoomRemovedEvent(Guid hotelId, Guid roomId)
        {
            HotelId = hotelId;
            RoomId = roomId;
        }
    }
}
