using MediatR;
using MediTrack.Application;
using Microsoft.AspNetCore.Mvc;

namespace MediTrack.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PhysicianController(ISender iSender) : ControllerBase
{
    private readonly ISender _iSender = iSender;

    [HttpGet]
    public async Task<IActionResult> GetAllPhysicians()
    {
        try
        {
            var response = await _iSender.Send(new GetPhysicianQuery());
            return Ok(response);
        }
        catch (Exception e)
        {
            throw new Exception($"{e.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPhysicianById(int id)
    {
        try
        {
            var response = await _iSender.Send(new GetPhysicianByIdQuery(id));
            if (response is null)
            {
                return NotFound();
            }

            return Ok(response);
        }
        catch (Exception e)
        {
            throw new Exception($"{e.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewPhysician(CreatePhysicianCommand command)
    {
        try
        {
            var newPhysician = await _iSender.Send(command);
            return Created("Created successfully", newPhysician);
        }
        catch (Exception e)
        {
            throw new Exception($"{e.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePhysician(int id, UpdatePhysicianCommand command)
    {
        if (id != command.id)
        {
            return BadRequest();
        }

        try
        {
            await _iSender.Send(command);
            return NoContent();
        }
        catch (Exception e)
        {
            throw new Exception($"{e.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePhysician(int id)
    {
        try
        {
            var physicianToBeDeleted = await _iSender.Send(new GetPhysicianByIdQuery(id));
            if (physicianToBeDeleted is null)
            {
                return NotFound();
            }

            await _iSender.Send(new DeletePhysicianCommand(physicianToBeDeleted));
            return NoContent();
        }
        catch (Exception e)
        {
            throw new Exception($"{e.Message}");
        }
    }
}


