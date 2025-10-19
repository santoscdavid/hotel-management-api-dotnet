using HotelManagement.API.DTOs.Response.Common;

namespace HotelManagement.API.DTOs.Response.Hotel;

public class GetAllHotelsResponse(
    IEnumerable<HotelSummaryResponse> hotels,
    int totalCount,
    int pageNumber,
    int pageSize)
    : PagedResponse<HotelSummaryResponse>(hotels, totalCount, pageNumber, pageSize);