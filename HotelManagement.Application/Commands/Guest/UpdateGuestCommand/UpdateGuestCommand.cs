using HotelManagement.Application.Common;
using MediatR;

namespace HotelManagement.Application.Commands.Guest.UpdateGuestCommand
{
    public sealed record UpdateGuestCommand(
            Guid GuestId,
            string? FullName,
            string? Email,
            string? PhoneNumber,
            string? DocumentNumber,
            DateTime? DateOfBirth
        ) : IRequest<Result>;
}
