using HotelManagement.Application.Common;
using HotelManagement.Domain.Repositories;
using MediatR;

namespace HotelManagement.Application.Commands.Guest.UpdateGuestCommand
{
    public sealed class UpdateGuestCommandHandler : IRequestHandler<UpdateGuestCommand, Result>
    {
        private readonly IGuestRepository _repository;

        public UpdateGuestCommandHandler(IGuestRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result> Handle(UpdateGuestCommand request, CancellationToken cancellationToken)
        {
            var guest = await _repository.GetByIdAsync(request.GuestId, cancellationToken);

            if (guest is null)
                return Result.Failure("Hóspede não encontrado");

            guest.UpdateDetails(fullName: request.FullName,
                                email: request.Email,
                                phoneNumber: request.PhoneNumber,
                                documentNumber: request.DocumentNumber,
                                dateOfBirth: request.DateOfBirth);

            _repository.Update(guest);
            await _repository.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
