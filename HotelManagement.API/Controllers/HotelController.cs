using HotelManagement.API.DTOs.Request.Hotel;
using HotelManagement.Application.Commands.Hotel.CreateHotelCommand;
using HotelManagement.Application.Commands.Hotel.DeleteHotelCommand;
using HotelManagement.Application.Commands.Hotel.UpdateHotelCommand;
using HotelManagement.Application.Queries.Hotel.GetAllHotels;
using HotelManagement.Application.Queries.Hotel.GetHotelById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.API.Controllers;

[ApiController]
[Route("api/hotel")]
public class HotelController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var hotels = await mediator.Send(new GetAllHotelsQuery());
        return Ok(hotels);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var hotel = await mediator.Send(new GetHotelByIdQuery(id));
        if (hotel == null) return NotFound();
        return Ok(hotel);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateHotelRequest request)
    {
        var command = new CreateHotelCommand(request.Name, request.Address, request.PhoneNumber, request.Email);
        var result = await mediator.Send(command);
        if (!result.IsSuccess) return BadRequest(result.Error);
        return CreatedAtAction(nameof(GetById), new { id = result.Value }, null);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateHotelRequest request)
    {
        var command = new UpdateHotelCommand(id, request.Name, request.Address, request.PhoneNumber, request.Email);
        var result = await mediator.Send(command);
        if (!result.IsSuccess) return BadRequest(result.Error);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteHotelCommand(id);
        var result = await mediator.Send(command);
        if (!result.IsSuccess) return BadRequest(result.Error);
        return NoContent();
    }
}