using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Hotels
{
    public sealed class EmployeeRemovedEvent : IDomainEvent
    {
        public Guid HotelId { get; }
        public Guid EmployeeId { get; }
        public EmployeeRemovedEvent(Guid hotelId, Guid employeeId)
        {
            HotelId = hotelId;
            EmployeeId = employeeId;
        }
    }
}
