using HotelManagement.Domain.Events.Base;
using HotelManagement.Domain.Events.Guest;
using HotelManagement.Domain.Interfaces;

namespace HotelManagement.Domain.Entities
{
    public class Guest : IHasDomainEvents
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected Guest() { }

        public Guid Id { get; private set; }
        public string FullName { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string PhoneNumber { get; private set; } = null!;
        public string DocumentNumber { get; private set; } = null!;
        public DateTime DateOfBirth { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public Guest(
            string fullName,
            string email,
            string phoneNumber,
            string documentNumber,
            DateTime dateOfBirth)
        {
            SetFullName(fullName);
            SetEmail(email);
            SetPhoneNumber(phoneNumber);
            SetDocumentNumber(documentNumber);
            SetDateOfBirth(dateOfBirth);

            CreatedAt = DateTime.UtcNow;
            AddDomainEvent(new GuestRegisteredEvent(Id, FullName, Email));
        }

        public void UpdateDetails(
            string? fullName = null,
            string? email = null,
            string? phoneNumber = null,
            string? documentNumber = null,
            DateTime? dateOfBirth = null)
        {
            if (!string.IsNullOrEmpty(fullName))
                SetFullName(fullName);

            if (!string.IsNullOrEmpty(email))
                SetEmail(email);

            if (!string.IsNullOrEmpty(phoneNumber))
                SetPhoneNumber(phoneNumber);

            if (!string.IsNullOrEmpty(documentNumber))
                SetDocumentNumber(documentNumber);

            if (dateOfBirth.HasValue)
                SetDateOfBirth(dateOfBirth.Value);

        }

        public void UpdateFullName(string fullName)
        {
            SetFullName(fullName);
            AddDomainEvent(new GuestUpdatedEvent(Id, nameof(FullName), fullName));
        }

        public void UpdateEmail(string email)
        {
            SetEmail(email);
            AddDomainEvent(new GuestUpdatedEvent(Id, nameof(Email), email));
        }

        public void UpdatePhoneNumber(string phoneNumber)
        {
            SetPhoneNumber(phoneNumber);
            AddDomainEvent(new GuestUpdatedEvent(Id, nameof(PhoneNumber), phoneNumber));
        }

        private void SetFullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Nome completo é obrigatório.", nameof(fullName));
            if (fullName.Length > 200)
                throw new ArgumentException("Nome completo muito longo.", nameof(fullName));

            FullName = fullName.Trim();
        }

        private void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email é obrigatório.", nameof(email));
            if (!email.Contains("@"))
                throw new ArgumentException("Email inválido.", nameof(email));

            Email = email.Trim();
        }

        private void SetPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Telefone é obrigatório.", nameof(phoneNumber));

            PhoneNumber = phoneNumber.Trim();
        }

        private void SetDocumentNumber(string documentNumber)
        {
            if (string.IsNullOrWhiteSpace(documentNumber))
                throw new ArgumentException("Número de documento inválido.", nameof(documentNumber));

            DocumentNumber = documentNumber;
        }

        private void SetDateOfBirth(DateTime dateOfBirth)
        {
            if (dateOfBirth > DateTime.UtcNow)
                throw new ArgumentException("Data de nascimento inválida.", nameof(dateOfBirth));

            DateOfBirth = dateOfBirth;
        }

        private void AddDomainEvent(IDomainEvent @event)
        {
            _domainEvents.Add(@event);
        }

        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}
