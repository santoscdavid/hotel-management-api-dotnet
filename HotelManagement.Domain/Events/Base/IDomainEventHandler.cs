using MediatR;

namespace HotelManagement.Domain.Events.Base
{
    public abstract class IDomainEventHandler<TEvent> : INotificationHandler<TEvent> where TEvent : IDomainEvent
    {
        public abstract Task Handle(TEvent notification, CancellationToken cancellationToken);

        protected Task LogAsync(string message)
        {
            Console.WriteLine($"[{typeof(TEvent).Name}] {message}");
            return Task.CompletedTask;
        }
    }
}
