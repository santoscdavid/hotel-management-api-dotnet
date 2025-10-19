using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Rooms
{
    public sealed class RoomNumberChangedDomainEvent : IDomainEvent
    {
        public Guid RoomId { get; }

        public int NewNumber;

        public RoomNumberChangedDomainEvent(Guid id, int newNumber)
        {
            RoomId = id;
            NewNumber = newNumber;
        }
    }
}
