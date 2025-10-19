using HotelManagement.Domain.Enums;
using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Rooms
{
    public sealed class RoomTypeChangedDomainEvent : IDomainEvent
    {
        public Guid RoomId { get; }
        public RoomType NewType { get; }

        public RoomTypeChangedDomainEvent(Guid roomId, RoomType newType)
        {
            RoomId = roomId;
            NewType = newType;
        }
    }
}
