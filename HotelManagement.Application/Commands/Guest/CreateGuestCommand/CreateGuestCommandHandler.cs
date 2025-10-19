using HotelManagement.Application.Common;
using HotelManagement.Domain.Repositories;
using MediatR;

namespace HotelManagement.Application.Commands.Guest.CreateGuestCommand
{
    public sealed class CreateGuestCommandHandler : IRequestHandler<CreateGuestCommand, Result<Guid>>
    {
        private readonly IGuestRepository _repository;

        public CreateGuestCommandHandler(IGuestRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Guid>> Handle(CreateGuestCommand request, CancellationToken cancellationToken)
        {
            var guest = new Domain.Entities.Guest(
                fullName: request.FullName,
                email: request.Email,
                phoneNumber: request.Email,
                documentNumber: request.DocumentNumber,
                dateOfBirth: request.DateOfBirth
            );

            await _repository.AddAsync(guest, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return Result<Guid>.Success(guest.Id);
        }
    }
}
