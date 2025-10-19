using HotelManagement.Application.Dtos.Hotels;
using HotelManagement.Domain.Repositories;
using MediatR;

namespace HotelManagement.Application.Queries.Hotel.GetAllHotels;

public class GetAllHotelsQueryHandler : IRequestHandler<GetAllHotelsQuery, IEnumerable<HotelDto>>
{
    private readonly IHotelRepository _repository;

    public GetAllHotelsQueryHandler(IHotelRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<HotelDto>> Handle(GetAllHotelsQuery request, CancellationToken cancellationToken)
    {
        var hotels = await _repository.GetAllAsync(cancellationToken);

        return hotels.Select(hotel => new HotelDto
        {
            Id = hotel.Id,
            Name = hotel.Name,
            Address = hotel.Address,
            CreatedAt = hotel.CreatedAt
        });
    }
}