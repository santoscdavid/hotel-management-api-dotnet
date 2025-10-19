using HotelManagement.API.DTOs.Request.Reservation;
using HotelManagement.Application.Commands.Reservation.CreateReservationCommand;
using HotelManagement.Application.Commands.Reservation.DeleteReservationCommand;
using HotelManagement.Application.Commands.Reservation.UpdateReservationCommand;
using HotelManagement.Application.Queries.Reservation.GetAllReservations;
using HotelManagement.Application.Queries.Reservation.GetReservationById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.API.Controllers;

[ApiController]
[Route("api/reservation")]
public class ReservationController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var reservations = await mediator.Send(new GetAllReservationsQuery());
        return Ok(reservations);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var reservation = await mediator.Send(new GetReservationByIdQuery(id));
        if (reservation == null) return NotFound();
        return Ok(reservation);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReservationRequest request)
    {
        var command = new CreateReservationCommand(
            request.RoomId,
            request.GuestId,
            request.CheckIn,
            request.CheckOut,
            request.TotalPrice
        );

        var result = await mediator.Send(command);
        if (!result.IsSuccess) return BadRequest(result.Error);

        return CreatedAtAction(nameof(GetById), new { id = result.Value }, null);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateReservationRequest request)
    {
        var command = new UpdateReservationCommand(
            id,
            request.RoomId,
            request.GuestId,
            request.CheckIn,
            request.CheckOut,
            request.TotalPrice
        );

        var result = await mediator.Send(command);
        if (!result.IsSuccess) return BadRequest(result.Error);

        return NoContent();
    }
    
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteReservationCommand(id);
        var result = await mediator.Send(command);
        if (!result.IsSuccess) return BadRequest(result.Error);

        return NoContent();
    }
}