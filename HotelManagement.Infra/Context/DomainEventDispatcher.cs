using HotelManagement.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Infra.Context
{
    public class DomainEventDispatcher
    {
        private readonly IMediator _mediator;

        public DomainEventDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task DispatchEventsAsync(DbContext context)
        {
            var domainEntities = context.ChangeTracker
                .Entries()
                .Where(e => e.Entity is IHasDomainEvents && ((IHasDomainEvents)e.Entity).DomainEvents.Any())
                .Select(e => (IHasDomainEvents)e.Entity)
                .ToList();

            var domainEvents = domainEntities
                .SelectMany(x => x.DomainEvents)
                .ToList();

            domainEntities.ForEach(entity => entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
            {
                await _mediator.Publish(domainEvent);
            }
        }
    }
}
