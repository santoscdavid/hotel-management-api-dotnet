using HotelManagement.Domain.Enums;
using HotelManagement.Domain.Events.Admin;
using HotelManagement.Domain.Events.Base;
using HotelManagement.Domain.Interfaces;

namespace HotelManagement.Domain.Entities
{
    public class Admin : IHasDomainEvents
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected Admin() { }

        public Guid Id { get; private set; }
        public string Username { get; private set; } = null!;
        public string Password { get; private set; } = null!;
        public PermissionType Permissions { get; private set; } = PermissionType.None;

        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; } = null!;

        public Admin(Guid employeeId, string username, string password, PermissionType permissions)
        {
            EmployeeId = employeeId;
            SetUsername(username);
            SetPassword(password);
            Permissions = permissions;

            AddDomainEvent(new AdminCreatedEvent(Id, Username, EmployeeId));
        }

        public void UpdateUsername(string username)
        {
            SetUsername(username);
            AddDomainEvent(new AdminUsernameChangedEvent(Id));
        }

        public void UpdatePassword(string password)
        {
            SetPassword(password);
            AddDomainEvent(new AdminPasswordChangedEvent(Id));
        }

        public void UpdatePermissions(PermissionType permissions)
        {
            Permissions = permissions;
            AddDomainEvent(new AdminPermissionsUpdatedEvent(Id, permissions));
        }

        private void SetUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username é obrigatório.", nameof(username));
            if (username.Length > 50)
                throw new ArgumentException("Username muito longo.", nameof(username));

            Username = username.Trim();
        }

        private void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password é obrigatória.", nameof(password));
            if (password.Length < 6)
                throw new ArgumentException("Password deve ter pelo menos 6 caracteres.", nameof(password));

            Password = password.Trim();
        }

        private void AddDomainEvent(IDomainEvent @event)
        {
            _domainEvents.Add(@event);
        }

        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}
