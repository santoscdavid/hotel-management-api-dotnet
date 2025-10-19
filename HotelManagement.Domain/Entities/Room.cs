using HotelManagement.Domain.Enums;
using HotelManagement.Domain.Events.Base;
using HotelManagement.Domain.Events.Rooms;
using HotelManagement.Domain.Interfaces;

namespace HotelManagement.Domain.Entities
{
    public class Room : IHasDomainEvents
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected Room()
        {
        }

        public Guid Id { get; private set; }
        public int Number { get; private set; }
        public int Capacity { get; private set; }
        public decimal PricePerNight { get; private set; }
        public bool IsAvailable { get; private set; }
        public RoomType RoomType { get; private set; }

        public Guid HotelId { get; private set; }
        public Hotel Hotel { get; private set; } = null!;

        public Room(int number, decimal pricePerNight, RoomType type, Guid hotelId)
        {
            SetNumber(number);
            SetPrice(pricePerNight);
            RoomType = type;
            IsAvailable = true;
            HotelId = hotelId;

            AddDomainEvent(new RoomCreatedDomainEvent(Id));
        }

        public void UpdateDetails(int? number = null, RoomType? type = null, decimal? pricePerNight = null)
        {
            if (number.HasValue)
                SetNumber(number.Value);

            if (type.HasValue)
                ChangeType(type.Value);

            if (pricePerNight.HasValue)
                SetPrice(pricePerNight.Value);
        }

        public void SetNumber(int newNumber)
        {
            if (newNumber <= 0)
                throw new ArgumentException("O Número do quarto deve ser maior que zero.");

            Number = newNumber;
            AddDomainEvent(new RoomNumberChangedDomainEvent(Id, newNumber));
        }

        public void SetPrice(decimal newPrice)
        {
            if (newPrice <= 0)
                throw new ArgumentException("O preço deve ser maior que zero.");

            if (newPrice == PricePerNight) return;
            PricePerNight = newPrice;
            AddDomainEvent(new RoomPriceChangedDomainEvent(Id, newPrice));
        }

        public void ChangeType(RoomType newType)
        {
            if (newType == RoomType) return;
            RoomType = newType;
            AddDomainEvent(new RoomTypeChangedDomainEvent(Id, newType));
        }

        public void MarkAsUnavailable()
        {
            if (!IsAvailable)
                throw new InvalidOperationException("O quarto já está indisponível.");

            IsAvailable = false;
            AddDomainEvent(new RoomMadeUnavailableDomainEvent(Id));
        }

        public void MarkAsAvailable()
        {
            if (IsAvailable)
                throw new InvalidOperationException("O quarto já está disponível.");

            IsAvailable = true;
            AddDomainEvent(new RoomMadeAvailableDomainEvent(Id));
        }

        private void AddDomainEvent(IDomainEvent @event)
        {
            _domainEvents.Add(@event);
        }

        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}