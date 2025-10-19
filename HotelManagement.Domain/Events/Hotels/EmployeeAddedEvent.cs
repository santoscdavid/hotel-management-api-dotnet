using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Hotels
{

    public sealed class EmployeeAddedEvent : IDomainEvent
    {
        public Guid HotelId { get; }
        public Guid EmployeeId { get; }
        public EmployeeAddedEvent(Guid hotelId, Guid employeeId)
        {
            HotelId = hotelId;
            EmployeeId = employeeId;
        }
    }
}
