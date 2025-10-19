using HotelManagement.Application.Dtos.Guests;
using HotelManagement.Application.Dtos.Room;
using HotelManagement.Domain.Repositories;
using MediatR;

namespace HotelManagement.Application.Queries.Guest.GetGuestById
{
    public class GetGuestByIdQueryHandler : IRequestHandler<GetGuestByIdQuery, GuestDto?>
    {
        private readonly IGuestRepository _guestRepository;

        public GetGuestByIdQueryHandler(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<GuestDto?> Handle(GetGuestByIdQuery request, CancellationToken cancellationToken)
        {
            var guest = await _guestRepository.GetByIdAsync(request.GuestId, cancellationToken);

            if (guest is null)
                return null;

            return new GuestDto
            {
                Id = guest.Id,
                Name = guest.FullName,
                Email = guest.Email,
                PhoneNumber = guest.PhoneNumber,
                DocumentNumber = guest.DocumentNumber,
                CreatedAt = guest.CreatedAt
            };
        }
    }
}