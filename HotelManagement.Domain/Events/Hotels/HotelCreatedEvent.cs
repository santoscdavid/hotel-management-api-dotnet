using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Hotels
{
    public sealed class HotelCreatedEvent : IDomainEvent
    {
        public Guid HotelId { get; }
        public string Name { get; }
        public string Address { get; }
        public string PhoneNumber { get; }
        public string Email { get; }

        public HotelCreatedEvent(Guid hotelId, string name, string address, string phoneNumber, string email)
        {
            HotelId = hotelId;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
