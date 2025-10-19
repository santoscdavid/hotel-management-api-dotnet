using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Rooms
{
    public sealed class RoomMadeUnavailableDomainEvent : IDomainEvent
    {
        public Guid RoomId { get; }

        public RoomMadeUnavailableDomainEvent(Guid roomId)
        {
            RoomId = roomId;
        }
    }
}
