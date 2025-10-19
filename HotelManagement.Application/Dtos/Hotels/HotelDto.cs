using HotelManagement.Application.Dtos.Employees;
using HotelManagement.Application.Dtos.Rooms;

namespace HotelManagement.Application.Dtos.Hotels
{
    public class HotelDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Address { get; init; } = string.Empty;
        public DateTime CreatedAt { get; init; }

        public IEnumerable<RoomSummaryDto> Rooms { get; init; } = new List<RoomSummaryDto>();
        public IEnumerable<EmployeeSummaryDto> Employees { get; init; } = new List<EmployeeSummaryDto>();
    }
}