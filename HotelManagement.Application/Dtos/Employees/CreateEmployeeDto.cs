using HotelManagement.Domain.Enums;

namespace HotelManagement.Application.Dtos.Employees
{
    public class CreateEmployeeDto
    {
        public string Name { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string PhoneNumber { get; init; } = string.Empty;
        public RoleType Role { get; init; }
    }
}
