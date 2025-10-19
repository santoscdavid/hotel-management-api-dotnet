using HotelManagement.Domain.Events.Base;
using HotelManagement.Domain.Events.Rooms;
using MediatR;

namespace HotelManagement.Application.EventHandlers.Room
{
    public sealed class RoomMadeUnavailableDomainEventHandler : IDomainEventHandler<RoomMadeUnavailableDomainEvent>
    {
        public override Task Handle(RoomMadeUnavailableDomainEvent notification, CancellationToken cancellationToken)
        {
            LogAsync($"🚫 Quarto {notification.RoomId} foi marcado como indisponível.");

            // _notificationService.NotifyStaff(...)

            return Task.CompletedTask;
        }
    }
}
