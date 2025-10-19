using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Employees
{
    public sealed class EmployeeUpdatedEvent : IDomainEvent
    {
        public Guid EmployeeId { get; }
        public string PropertyName { get; }
        public string NewValue { get; }

        public EmployeeUpdatedEvent(Guid employeeId, string propertyName, string newValue)
        {
            EmployeeId = employeeId;
            PropertyName = propertyName;
            NewValue = newValue;
        }
    }
}
