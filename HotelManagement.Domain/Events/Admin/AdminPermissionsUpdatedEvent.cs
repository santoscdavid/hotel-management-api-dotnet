using HotelManagement.Domain.Enums;
using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Admin
{
    public sealed class AdminPermissionsUpdatedEvent : IDomainEvent
    {
        public Guid AdminId { get; }
        public PermissionType Permissions { get; }

        public AdminPermissionsUpdatedEvent(Guid adminId, PermissionType permissions)
        {
            AdminId = adminId;
            Permissions = permissions;
        }
    }
}
