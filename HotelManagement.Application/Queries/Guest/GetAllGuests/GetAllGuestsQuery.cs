using HotelManagement.Application.Common;
using HotelManagement.Application.Dtos.Guests;
using MediatR;

namespace HotelManagement.Application.Queries.Guest.GetAllGuests
{
    public sealed record GetAllGuestsQuery : IRequest<IEnumerable<GuestDto>>; 
}