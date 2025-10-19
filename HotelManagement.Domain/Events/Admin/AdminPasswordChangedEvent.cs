using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Admin
{
    public sealed class AdminPasswordChangedEvent : IDomainEvent
    {
        public Guid AdminId { get; }

        public AdminPasswordChangedEvent(Guid adminId)
        {
            AdminId = adminId;
        }
    }
}
