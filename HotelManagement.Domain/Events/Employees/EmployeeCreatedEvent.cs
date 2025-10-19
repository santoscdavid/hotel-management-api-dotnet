using HotelManagement.Domain.Enums;
using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Employees
{
    public sealed class EmployeeCreatedEvent : IDomainEvent
    {
        public Guid EmployeeId { get; }
        public string Name { get; }
        public string Email { get; }
        public string PhoneNumber { get; }
        public RoleType Role { get; }

        public EmployeeCreatedEvent(Guid employeeId, string name, string email, string phoneNumber, RoleType role)
        {
            EmployeeId = employeeId;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Role = role;
        }
    }
}
