using HotelManagement.API.DTOs.Request.Room;
using HotelManagement.Application.Commands.Room.CreateRoomCommand;
using HotelManagement.Application.Commands.Room.DeleteRoomCommand;
using HotelManagement.Application.Commands.Room.UpdateRoomCommand;
using HotelManagement.Application.Queries.Room.GetAllRooms;
using HotelManagement.Application.Queries.Room.GetRoomById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.API.Controllers;

[ApiController]
[Route("api/room")]
public class RoomController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var rooms = await mediator.Send(new GetAllRoomsQuery());
        return Ok(rooms);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var room = await mediator.Send(new GetRoomByIdQuery(id));
        if (room == null) return NotFound();
        return Ok(room); // room é RoomResponseDto
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRoomRequest request)
    {
        var command = new CreateRoomCommand(
            request.HotelId,
            request.Number,
            request.PricePerNight,
            request.Type
        );

        var result = await mediator.Send(command);
        if (!result.IsSuccess) return BadRequest(result.Error);

        return CreatedAtAction(nameof(GetById), new { id = result.Value }, null);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRoomRequest request)
    {
        var command = new UpdateRoomCommand(
            id,
            request.HotelId,
            request.Number,
            request.Type,
            request.PricePerNight
        );

        var result = await mediator.Send(command);
        if (!result.IsSuccess) return BadRequest(result.Error);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteRoomCommand(id);
        var result = await mediator.Send(command);
        if (!result.IsSuccess) return BadRequest(result.Error);

        return NoContent();
    }
}