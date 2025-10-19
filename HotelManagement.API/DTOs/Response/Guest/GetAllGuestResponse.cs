using HotelManagement.API.DTOs.Response.Common;

namespace HotelManagement.API.DTOs.Response.Guest;

public class GetAllGuestsResponse(
    IEnumerable<GuestSummaryResponse> guests,
    int totalCount,
    int pageNumber,
    int pageSize)
    : PagedResponse<GuestSummaryResponse>(guests, totalCount, pageNumber, pageSize);