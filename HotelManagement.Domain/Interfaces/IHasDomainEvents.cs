using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Interfaces
{
    public interface IHasDomainEvents
    {
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
        void ClearDomainEvents();
    }
}
