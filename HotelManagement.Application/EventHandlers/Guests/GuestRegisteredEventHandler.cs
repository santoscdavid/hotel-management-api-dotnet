using HotelManagement.Domain.Events.Base;
using HotelManagement.Domain.Events.Guest;
using MediatR;

namespace HotelManagement.Application.EventHandlers.Guests
{
    public sealed class GuestRegisteredEventHandler : IDomainEventHandler<GuestRegisteredEvent>
    {
        public override Task Handle(GuestRegisteredEvent notification, CancellationToken cancellationToken)
        {
            LogAsync($"✅ Hóspede criado: {notification.GuestId}");
            
            // _emailService.SendWelcomeEmail(...);

            return Task.CompletedTask;
        }
    }
}
