using HotelManagement.Domain.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Domain.Events.Admin
{
    public sealed class AdminUsernameChangedEvent : IDomainEvent
    {
        public Guid AdminId { get; }

        public AdminUsernameChangedEvent(Guid adminId)
        {
            AdminId = adminId;
        }
    }
}
