using HotelManagement.Application.Common;
using MediatR;

namespace HotelManagement.Application.Commands.Guest.CreateGuestCommand
{
    public sealed record CreateGuestCommand(
            string FullName,
            string Email,
            string PhoneNumber,
            string DocumentNumber,
            DateTime DateOfBirth
        ) : IRequest<Result<Guid>>;
}
