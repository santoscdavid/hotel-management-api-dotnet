using HotelManagement.Application.Common;
using HotelManagement.Domain.Repositories;
using MediatR;

namespace HotelManagement.Application.Commands.Guest.DeleteGuestCommand
{
    public class DeleteGuestCommandHandler : IRequestHandler<DeleteGuestCommand, Result>
    {
        private readonly IGuestRepository _repository;

        public DeleteGuestCommandHandler(IGuestRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(DeleteGuestCommand request, CancellationToken cancellationToken)
        {
            var guest = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (guest is null)
                return Result.Failure("Hóspede não encontrado.");

            _repository.Delete(guest);

            await _repository.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}