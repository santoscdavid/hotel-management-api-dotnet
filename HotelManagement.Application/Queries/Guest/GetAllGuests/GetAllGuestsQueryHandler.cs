using HotelManagement.Application.Dtos.Guests;
using HotelManagement.Domain.Repositories;
using MediatR;

namespace HotelManagement.Application.Queries.Guest.GetAllGuests
{
    public class GetAllGuestsQueryHandler : IRequestHandler<GetAllGuestsQuery, IEnumerable<GuestDto>>
    {
        private readonly IGuestRepository _repository;

        public GetAllGuestsQueryHandler(IGuestRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GuestDto>> Handle(GetAllGuestsQuery request, CancellationToken cancellationToken)
        {
            var guests = await _repository.GetAllAsync(cancellationToken);

            return guests.Select(guest => new GuestDto
            {
                Id = guest.Id,
                Name = guest.FullName,
                Email = guest.Email,
                PhoneNumber = guest.PhoneNumber,
                DocumentNumber = guest.DocumentNumber,
                CreatedAt = guest.CreatedAt,
            });
        }
    }
}