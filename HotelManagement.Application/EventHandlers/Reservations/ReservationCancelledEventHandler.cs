using HotelManagement.Domain.Events.Base;
using HotelManagement.Domain.Events.Reservation;

namespace HotelManagement.Application.EventHandlers.Reservations
{
    public sealed class ReservationCancelledEventHandler : IDomainEventHandler<ReservationCancelledEvent>
    {
        public override Task Handle(ReservationCancelledEvent notification, CancellationToken cancellationToken)
        {
            LogAsync($"⚠️ Reserva {notification.ReservationId} cancelada.");

            // _roomService.MarkAsAvailable(domainEvent.RoomId);
            // _emailService.SendCancellationEmail(...);

            return Task.CompletedTask;
        }
    }
}
