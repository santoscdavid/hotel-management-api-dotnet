using HotelManagement.Application.Dtos.Guests;
using MediatR;

namespace HotelManagement.Application.Queries.Guest.GetGuestById
{
    public sealed record GetGuestByIdQuery(Guid GuestId) :  IRequest<GuestDto?>;
}