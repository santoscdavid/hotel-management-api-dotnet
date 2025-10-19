using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Admin
{
    public sealed class AdminCreatedEvent : IDomainEvent
    {
        public Guid AdminId { get; }
        public string Username { get; }
        public Guid EmployeeId { get; }

        public AdminCreatedEvent(Guid adminId, string username, Guid employeeId)
        {
            AdminId = adminId;
            Username = username;
            EmployeeId = employeeId;
        }
    }   
}
