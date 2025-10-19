using HotelManagement.Domain.Events.Base;
using HotelManagement.Domain.Events.Hotels;
using HotelManagement.Domain.Interfaces;

namespace HotelManagement.Domain.Entities
{
    public class Hotel : IHasDomainEvents
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected Hotel()
        {
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public string Address { get; private set; } = null!;
        public string PhoneNumber { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        private readonly List<Room> _rooms = [];
        public IReadOnlyCollection<Room> Rooms => _rooms.AsReadOnly();

        private readonly List<Employee> _employees = [];
        public IReadOnlyCollection<Employee> Employees => _employees.AsReadOnly();

        public Hotel(string name, string address, string phoneNumber, string email)
        {
            SetName(name);
            SetAddress(address);
            SetPhoneNumber(phoneNumber);
            SetEmail(email);
            CreatedAt = DateTime.UtcNow;

            AddDomainEvent(new HotelCreatedEvent(Id, Name, Address, PhoneNumber, Email));
        }

        public void Update(
            string? name = null,
            string? address = null,
            string? phoneNumber = null,
            string? email = null)
        {
            if (!string.IsNullOrWhiteSpace(name) && name != Name)
            {
                UpdateName(name);
            }

            if (!string.IsNullOrWhiteSpace(address) && address != Address)
            {
                UpdateAddress(address);
            }

            if (!string.IsNullOrWhiteSpace(phoneNumber) && phoneNumber != PhoneNumber)
            {
                UpdatePhoneNumber(phoneNumber);
            }

            if (!string.IsNullOrWhiteSpace(email) && email != Email)
            {
                UpdateEmail(email);
            }
        }

        public void AddRoom(Room? room)
        {
            if (room != null)
                _rooms.Add(room);
            else
                throw new ArgumentNullException(nameof(room));

            AddDomainEvent(new RoomAddedEvent(Id, room.Id));
        }

        public void RemoveRoom(Room? room)
        {
            if (room != null)
                _rooms.Remove(room);
            else
                throw new ArgumentNullException(nameof(room));

            AddDomainEvent(new RoomRemovedEvent(Id, room.Id));
        }

        public void AddEmployee(Employee? employee)
        {
            if (employee != null)
                _employees.Add(employee);
            else
                throw new ArgumentNullException(nameof(employee));

            AddDomainEvent(new EmployeeAddedEvent(Id, employee.Id));
        }

        public void RemoveEmployee(Employee? employee)
        {
            if (employee != null)
                _employees.Remove(employee);
            else
                throw new ArgumentNullException(nameof(employee));

            AddDomainEvent(new EmployeeRemovedEvent(Id, employee.Id));
        }

        public void UpdateName(string name)
        {
            SetName(name);
            AddDomainEvent(new HotelUpdatedEvent(Id, nameof(Name), name));
        }

        public void UpdateAddress(string address)
        {
            SetAddress(address);
            AddDomainEvent(new HotelUpdatedEvent(Id, nameof(Address), address));
        }

        public void UpdatePhoneNumber(string phoneNumber)
        {
            SetPhoneNumber(phoneNumber);
            AddDomainEvent(new HotelUpdatedEvent(Id, nameof(PhoneNumber), phoneNumber));
        }

        public void UpdateEmail(string email)
        {
            SetEmail(email);
            AddDomainEvent(new HotelUpdatedEvent(Id, nameof(Email), email));
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nome do hotel é obrigatório.", nameof(name));
            if (name.Length > 200)
                throw new ArgumentException("Nome do hotel muito longo.", nameof(name));

            Name = name.Trim();
        }

        private void SetAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Endereço é obrigatório.", nameof(address));
            if (address.Length > 300)
                throw new ArgumentException("Endereço muito longo.", nameof(address));

            Address = address.Trim();
        }

        private void SetPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Telefone é obrigatório.", nameof(phoneNumber));
            if (phoneNumber.Length > 20)
                throw new ArgumentException("Telefone muito longo.", nameof(phoneNumber));

            PhoneNumber = phoneNumber.Trim();
        }

        private void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email é obrigatório.", nameof(email));
            if (!email.Contains('@'))
                throw new ArgumentException("Email inválido.", nameof(email));

            Email = email.Trim();
        }

        private void AddDomainEvent(IDomainEvent @event)
        {
            _domainEvents.Add(@event);
        }

        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}