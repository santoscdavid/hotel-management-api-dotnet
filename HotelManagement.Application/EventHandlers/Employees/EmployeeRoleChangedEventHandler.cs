using HotelManagement.Domain.Events.Base;
using HotelManagement.Domain.Events.Employees;

namespace HotelManagement.Application.EventHandlers.Employees
{
    public sealed class EmployeeRoleChangedEventHandler : IDomainEventHandler<EmployeeUpdatedEvent>
    {
        public override Task Handle(EmployeeUpdatedEvent notification, CancellationToken cancellationToken)
        {
            LogAsync($"Cargo do funcionário {notification.EmployeeId} alterado");
            
            return Task.CompletedTask;
        }
    }
}
