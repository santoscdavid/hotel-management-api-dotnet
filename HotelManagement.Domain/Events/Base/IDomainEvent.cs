using MediatR;

namespace HotelManagement.Domain.Events.Base
{
    public abstract class IDomainEvent : INotification
    {
        public DateTime OccurredOn { get; } = DateTime.Now;
    }
}
