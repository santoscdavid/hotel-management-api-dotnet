using HotelManagement.Application.Common;
using MediatR;

namespace HotelManagement.Application.Commands.Guest.DeleteGuestCommand
{
    public sealed record DeleteGuestCommand(Guid Id) : IRequest<Result>;
}