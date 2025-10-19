using HotelManagement.API.DTOs.Response.Common;

namespace HotelManagement.API.DTOs.Response.Room;

public class GetAllRoomsResponse(
    IEnumerable<RoomSummaryResponse> rooms,
    int totalCount,
    int pageNumber,
    int pageSize)
    : PagedResponse<RoomSummaryResponse>(rooms, totalCount, pageNumber, pageSize);