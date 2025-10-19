using HotelManagement.Application.Dtos.Hotels;
using MediatR;

namespace HotelManagement.Application.Queries.Hotel.GetHotelById;

public sealed record GetHotelByIdQuery(Guid Id) : IRequest<HotelDto?>;