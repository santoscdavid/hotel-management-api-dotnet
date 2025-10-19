using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Rooms
{
    public sealed class RoomPriceChangedDomainEvent : IDomainEvent
    {
        public Guid RoomId { get; }
        public decimal NewPrice { get; }

        public RoomPriceChangedDomainEvent(Guid roomId, decimal newPrice)
        {
            RoomId = roomId;
            NewPrice = newPrice;
        }
    }
}
