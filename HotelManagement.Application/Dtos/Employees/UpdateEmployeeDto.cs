using HotelManagement.Domain.Enums;

namespace HotelManagement.Application.Dtos.Employees
{
    public class UpdateEmployeeDto
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
        public RoleType? Role { get; init; }
    }
}
