using MediatR;
using MediTrack.Application;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MediTrack.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController(ISender iSender) : ControllerBase
{
    private readonly ISender _iSender = iSender;

    [HttpGet]
    public async Task<IActionResult> GetAllPatients()
    {
        try
        {
            var response = await _iSender.Send(new GetPatientQuery());
            return Ok(response);
        }
        catch (Exception e)
        {
            throw new Exception($"{e.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatientById(int id)
    {
        try
        {
            var response = await _iSender.Send(new GetPatientByIdQuery(id));
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
    public async Task<IActionResult> CreateNewPatient(CreatePatientCommand command)
    {
        try
        {
            var newPatient = await _iSender.Send(command);
            return Created("Created successfully", newPatient);
        }
        catch (Exception e)
        {
            throw new Exception($"{e.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePatient(int id, UpdatePatientCommand command)
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
    public async Task<IActionResult> DeletePatient(int id)
    {
        try
        {
            var patientToBeDeleted = await _iSender.Send(new GetPatientByIdQuery(id));
            if (patientToBeDeleted is null)
            {
                return NotFound();
            }

            await _iSender.Send(new DeletePatientCommand(patientToBeDeleted));
            return NoContent();
        }
        catch (Exception e)
        {
            throw new Exception($"{e.Message}");
        }
    }
}
