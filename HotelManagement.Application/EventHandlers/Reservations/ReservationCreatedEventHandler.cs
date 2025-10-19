using HotelManagement.Domain.Events.Base;
using HotelManagement.Domain.Events.Reservation;

namespace HotelManagement.Application.EventHandlers.Reservations
{
    public sealed class ReservationCreatedEventHandler : IDomainEventHandler<ReservationCreatedEvent>
    {
        public override Task Handle(ReservationCreatedEvent notification, CancellationToken cancellationToken)
        {
            LogAsync($"✅ Reserva criada: {notification.Id} para o hóspede {notification.GuestId}");

            // _emailService.SendReservationConfirmation(...);

            return Task.CompletedTask;
        }
    }
}
