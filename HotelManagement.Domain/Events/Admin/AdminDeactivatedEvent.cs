using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Admin
{
    public sealed class AdminDeactivatedEvent : IDomainEvent
    {
        public Guid AdminId { get; }

        public AdminDeactivatedEvent(Guid adminId)
        {
            AdminId = adminId;
        }
    }
}
