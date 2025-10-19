using HotelManagement.Domain.Enums;

namespace HotelManagement.Application.Dtos.Admins
{
    public class UpdateAdminDto
    {
        public Guid Id { get; init; }
        public string? Username { get; init; }
        public string? Password { get; init; }

        public IEnumerable<PermissionType>? Permissions { get; init; }
    }
}
