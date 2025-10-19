using HotelManagement.Domain.Enums;

namespace HotelManagement.Application.Dtos.Employees
{
    public class EmployeeDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string PhoneNumber { get; init; } = string.Empty;
        public RoleType Role { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}
