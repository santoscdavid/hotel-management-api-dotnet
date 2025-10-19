using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Employees
{
    public sealed class EmployeeRemovedEvent : IDomainEvent
    {
        public Guid EmployeeId { get; }

        public EmployeeRemovedEvent(Guid employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
