using HotelManagement.API.DTOs.Request.Guest;
using HotelManagement.API.DTOs.Response.Guest;
using HotelManagement.Application.Commands.Guest.CreateGuestCommand;
using HotelManagement.Application.Commands.Guest.DeleteGuestCommand;
using HotelManagement.Application.Commands.Guest.UpdateGuestCommand;
using HotelManagement.Application.Queries.Guest.GetAllGuests;
using HotelManagement.Application.Queries.Guest.GetGuestById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.API.Controllers;

[ApiController]
[Route("api/guest")]
public class GuestController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var guests = await mediator.Send(new GetAllGuestsQuery());
        return Ok(guests);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var guest = await mediator.Send(new GetGuestByIdQuery(id));
        if (guest == null) return NotFound();
        return Ok(guest);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateGuestRequest request)
    {
        var command = new CreateGuestCommand(
            request.FullName,
            request.Email,
            request.PhoneNumber,
            request.DocumentNumber,
            request.DateOfBirth
        );

        var result = await mediator.Send(command);
        if (!result.IsSuccess) return BadRequest(result.Error);

        return CreatedAtAction(nameof(GetById), new { id = result.Value }, null);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateGuestRequest request)
    {
        var command = new UpdateGuestCommand(
            id,
            request.FullName,
            request.Email,
            request.PhoneNumber,
            request.DocumentNumber,
            request.DateOfBirth
        );

        var result = await mediator.Send(command);
        if (!result.IsSuccess) return BadRequest(result.Error);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteGuestCommand(id);
        var result = await mediator.Send(command);
        if (!result.IsSuccess) return BadRequest(result.Error);

        return NoContent();
    }
}