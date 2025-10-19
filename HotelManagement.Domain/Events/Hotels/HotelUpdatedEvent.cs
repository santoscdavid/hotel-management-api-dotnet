using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Hotels
{
    public sealed class HotelUpdatedEvent : IDomainEvent
    {
        public Guid HotelId { get; }
        public string PropertyName { get; }
        public string NewValue { get; }

        public HotelUpdatedEvent(Guid hotelId, string propertyName, string newValue)
        {
            HotelId = hotelId;
            PropertyName = propertyName;
            NewValue = newValue;
        }
    }
}
