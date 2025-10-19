using HotelManagement.Domain.Events.Base;
using HotelManagement.Domain.Events.Employees;
using MediatR;

namespace HotelManagement.Application.EventHandlers.Employees
{
    public sealed class EmployeeCreatedEventHandler : IDomainEventHandler<EmployeeCreatedEvent>
    {
        public override Task Handle(EmployeeCreatedEvent notification, CancellationToken cancellationToken)
        {
            LogAsync($"Novo funcionário criado: {notification.Name} (Cargo: {notification.Role})");
            
            return Task.CompletedTask;
        }
    }
}
