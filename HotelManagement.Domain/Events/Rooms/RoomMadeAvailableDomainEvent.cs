using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Rooms
{
    public sealed class RoomMadeAvailableDomainEvent : IDomainEvent
    {
        public Guid RoomId { get; }

        public RoomMadeAvailableDomainEvent(Guid roomId)
        {
            RoomId = roomId;
        }
    }
}
