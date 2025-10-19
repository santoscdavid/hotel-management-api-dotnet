using HotelManagement.Domain.Enums;
using HotelManagement.Domain.Events.Base;
using HotelManagement.Domain.Events.Employees;
using HotelManagement.Domain.Interfaces;

namespace HotelManagement.Domain.Entities
{
    public class Employee : IHasDomainEvents
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected Employee() { }

        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public string PhoneNumber { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public RoleType Role { get; private set; }

        public Guid HotelId { get; private set; }
        public Hotel Hotel { get; private set; } = null!;

        public Employee(Guid hotelId, string name, string phoneNumber, string email, RoleType role)
        {
            SetName(name);
            SetPhoneNumber(phoneNumber);
            SetEmail(email);

            HotelId = hotelId;
            Role = role;

            AddDomainEvent(new EmployeeCreatedEvent(Id, Name, Email, PhoneNumber, Role));
        }

        public void UpdateName(string name)
        {
            SetName(name);
            AddDomainEvent(new EmployeeUpdatedEvent(Id, nameof(name), Name));
        }

        public void UpdatePhoneNumber(string phoneNumber)
        {
            SetPhoneNumber(phoneNumber);
            AddDomainEvent(new EmployeeUpdatedEvent(Id, nameof(phoneNumber), PhoneNumber));
        }

        public void UpdateEmail(string email)
        {
            SetEmail(email);
            AddDomainEvent(new EmployeeUpdatedEvent(Id, nameof(email), Email));
        }

        public void UpdateRole(RoleType role)
        {
            Role = role;
            AddDomainEvent(new EmployeeUpdatedEvent(Id, nameof(role), Role.ToString()));
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nome é obrigatório.", nameof(name));
            if (name.Length > 100)
                throw new ArgumentException("Nome muito longo.", nameof(name));

            Name = name.Trim();
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
            if (!email.Contains("@"))
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
