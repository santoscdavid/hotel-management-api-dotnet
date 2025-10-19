using HotelManagement.Domain.Enums;

namespace HotelManagement.Application.Dtos.Admins
{
    public class AdminDto
    {
        public Guid Id { get; init; }
        public string Username { get; init; } = string.Empty;
        public Guid EmployeeId { get; init; }
        public string? EmployeeName { get; init; }

        public IEnumerable<PermissionType> Permissions { get; init; } = new List<PermissionType>();

        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }

}
