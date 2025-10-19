using HotelManagement.Domain.Enums;
using HotelManagement.Domain.Events.Base;
using HotelManagement.Domain.Events.Reservation;
using HotelManagement.Domain.Interfaces;

namespace HotelManagement.Domain.Entities
{
    public class Reservation : IHasDomainEvents
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected Reservation()
        {
        }

        public Guid Id { get; private set; }
        public Guid RoomId { get; private set; }
        public Room Room { get; private set; } = null!;
        public Guid GuestId { get; private set; }
        public Guest Guest { get; private set; } = null!;
        public decimal TotalPrice { get; private set; }
        public DateTime CheckIn { get; private set; }
        public DateTime CheckOut { get; private set; }
        public ReservationStatusType Status { get; private set; } = ReservationStatusType.Pending;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public Reservation(Guid guestId, Guid roomId, DateTime checkIn, DateTime checkOut, decimal totalPrice)
        {
            SetDates(checkIn, checkOut);
            SetTotalPrice(totalPrice);

            GuestId = guestId;
            RoomId = roomId;

            Status = ReservationStatusType.Pending;
            CreatedAt = DateTime.UtcNow;

            AddDomainEvent(new ReservationCreatedEvent(Id, GuestId, RoomId, CheckIn, CheckOut));
        }

        public void Update(
            DateTime? checkIn = null,
            DateTime? checkOut = null,
            decimal? totalPrice = null)
        {
            EnsureCanModify();

            if (checkIn.HasValue || checkOut.HasValue)
            {
                var newCheckIn = checkIn ?? CheckIn;
                var newCheckOut = checkOut ?? CheckOut;

                if (newCheckIn != CheckIn || newCheckOut != CheckOut)
                {
                    SetDates(newCheckIn, newCheckOut);
                    AddDomainEvent(new ReservationDatesChangedEvent(Id, newCheckIn, newCheckOut));
                }
            }

            if (!totalPrice.HasValue || totalPrice.Value == TotalPrice) return;
            SetTotalPrice(totalPrice.Value);
            AddDomainEvent(new ReservationPriceChangedEvent(Id, totalPrice.Value));
        }

        public void Confirm()
        {
            if (Status != ReservationStatusType.Pending)
                throw new InvalidOperationException("Somente reservas pendentes podem ser confirmadas.");

            Status = ReservationStatusType.Confirmed;

            AddDomainEvent(new ReservationConfirmedEvent(Id));
        }

        public void Cancel()
        {
            if (Status == ReservationStatusType.Cancelled)
                throw new InvalidOperationException("Reserva já está cancelada.");

            Status = ReservationStatusType.Cancelled;

            AddDomainEvent(new ReservationCancelledEvent(Id));
        }

        public void UpdateDates(DateTime checkIn, DateTime checkOut)
        {
            EnsureCanModify();
            SetDates(checkIn, checkOut);
            AddDomainEvent(new ReservationDatesChangedEvent(Id, checkIn, checkOut));
        }

        public void UpdateTotalPrice(decimal totalPrice)
        {
            EnsureCanModify();
            SetTotalPrice(totalPrice);
            AddDomainEvent(new ReservationPriceChangedEvent(Id, totalPrice));
        }

        private void SetDates(DateTime checkIn, DateTime checkOut)
        {
            if (checkIn.Date < DateTime.UtcNow.Date)
                throw new ArgumentException("Check-in não pode ser no passado.", nameof(checkIn));
            if (checkOut <= checkIn)
                throw new ArgumentException("Check-out deve ser após o check-in.", nameof(checkOut));

            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        private void SetTotalPrice(decimal price)
        {
            if (price <= 0)
                throw new ArgumentException("Preço total deve ser positivo.", nameof(price));

            TotalPrice = price;
        }

        private void EnsureCanModify()
        {
            if (Status == ReservationStatusType.Cancelled)
                throw new InvalidOperationException("Não é possível alterar uma reserva cancelada.");
        }

        private void AddDomainEvent(IDomainEvent @event)
        {
            _domainEvents.Add(@event);
        }

        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}