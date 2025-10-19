using HotelManagement.Domain.Enums;

namespace HotelManagement.Application.Dtos.Admins
{
    public class CreateAdminDto
    {
        public string Username { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
        public Guid EmployeeId { get; init; }

        public IEnumerable<PermissionType> Permissions { get; init; } = new List<PermissionType>();
    }
}
