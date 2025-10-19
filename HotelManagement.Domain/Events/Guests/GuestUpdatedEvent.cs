using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Guest
{
    public sealed class GuestUpdatedEvent : IDomainEvent
    {
        public Guid GuestId { get; }
        public string PropertyName { get; }
        public string NewValue { get; }

        public GuestUpdatedEvent(Guid guestId, string propertyName, string newValue)
        {
            GuestId = guestId;
            PropertyName = propertyName;
            NewValue = newValue;
        }
    }
}
