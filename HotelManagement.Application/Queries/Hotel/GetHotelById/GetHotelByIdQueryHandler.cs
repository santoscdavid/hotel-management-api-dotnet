using HotelManagement.Application.Dtos.Hotels;
using HotelManagement.Domain.Repositories;
using MediatR;

namespace HotelManagement.Application.Queries.Hotel.GetHotelById;

public class GetHotelByIdQueryHandler : IRequestHandler<GetHotelByIdQuery, HotelDto?>
{
    private readonly IHotelRepository _repository;

    public GetHotelByIdQueryHandler(IHotelRepository repository)
    {
        _repository = repository;
    }

    public async Task<HotelDto?> Handle(GetHotelByIdQuery request, CancellationToken cancellationToken)
    {
        var hotel = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (hotel is null)
            return null;

        return new HotelDto
        {
            Id = hotel.Id,
            Name = hotel.Name,
            Address = hotel.Address,
            CreatedAt = hotel.CreatedAt
        };
    }
}