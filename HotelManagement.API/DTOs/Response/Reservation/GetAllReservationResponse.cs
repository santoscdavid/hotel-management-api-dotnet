using HotelManagement.API.DTOs.Response.Common;

namespace HotelManagement.API.DTOs.Response.Reservation;

public class GetAllReservationsResponse(
    IEnumerable<ReservationSummaryResponse> reservations,
    int totalCount,
    int pageNumber,
    int pageSize)
    : PagedResponse<ReservationSummaryResponse>(reservations, totalCount, pageNumber, pageSize);