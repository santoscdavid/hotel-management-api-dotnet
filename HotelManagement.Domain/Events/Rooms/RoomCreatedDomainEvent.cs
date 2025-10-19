using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Rooms
{
    public sealed class RoomCreatedDomainEvent : IDomainEvent
    {
        public Guid RoomId { get; }

        public RoomCreatedDomainEvent(Guid roomId)
        {
            RoomId = roomId;
        }
    }
}
