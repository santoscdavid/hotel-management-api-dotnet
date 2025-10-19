using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Hotels
{
    public sealed class HotelClosedEvent : IDomainEvent
    {
        public Guid HotelId { get; }

        public HotelClosedEvent(Guid hotelId)
        {
            HotelId = hotelId;
        }
    }
}
