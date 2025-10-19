using HotelManagement.Domain.Events.Base;
using HotelManagement.Domain.Events.Reservation;

namespace HotelManagement.Application.EventHandlers.Reservations
{
    public sealed class ReservationCheckedOutEventHandler : IDomainEventHandler<ReservationCheckedOutEvent>
    {
        public override Task Handle(ReservationCheckedOutEvent notification, CancellationToken cancellationToken)
        {
            LogAsync($"Check-out realizado para Reserva {notification.ReservationId}");

            // _roomService.MarkAsAvailable(domainEvent.RoomId);

            return Task.CompletedTask;
        }
    }
}
