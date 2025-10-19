using HotelManagement.Application.Dtos.Hotels;
using MediatR;

namespace HotelManagement.Application.Queries.Hotel.GetAllHotels;

public sealed record GetAllHotelsQuery : IRequest<IEnumerable<HotelDto>>;