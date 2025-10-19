using HotelManagement.Domain.Entities;
using HotelManagement.Domain.Events.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Infra.Context
{
    public class HotelDbContext : DbContext
    {
        private readonly IMediator _mediator;
        private readonly DomainEventDispatcher _dispatcher;

        public HotelDbContext(DbContextOptions<HotelDbContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
            _dispatcher = new DomainEventDispatcher(_mediator);
        }

        public DbSet<Room> Rooms => Set<Room>();
        public DbSet<Guest> Guests => Set<Guest>();
        public DbSet<Reservation> Reservations => Set<Reservation>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Hotel> Hotels => Set<Hotel>();
        public DbSet<Admin> Admins => Set<Admin>();

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            await _dispatcher.DispatchEventsAsync(this);

            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HotelDbContext).Assembly);

            modelBuilder.Ignore<IDomainEvent>();
        }
    }
}