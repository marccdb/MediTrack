using MediatR;
using MediTrack.Application;
using Microsoft.AspNetCore.Mvc;

namespace MediTrack.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MedicalRecordController(ISender iSender) : ControllerBase
{
    private readonly ISender _iSender = iSender;

    [HttpGet]
    public async Task<IActionResult> GetAllMedicalRecords()
    {
        try
        {
            var response = await _iSender.Send(new GetMedicalRecordQuery());
            return Ok(response);
        }
        catch (Exception e)
        {
            throw new Exception($"{e.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMedicalRecordById(int id)
    {
        try
        {
            var response = await _iSender.Send(new GetMedicalRecordByIdQuery(id));
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
    public async Task<IActionResult> CreateNewMedicalRecord(CreateMedicalRecordCommand command)
    {
        try
        {
            var newMedicalRecord = await _iSender.Send(command);
            return Created("Created successfully", newMedicalRecord);
        }
        catch (Exception e)
        {
            throw new Exception($"{e.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMedicalRecord(int id, UpdateMedicalRecordCommand command)
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
    public async Task<IActionResult> DeleteMedicalRecord(int id)
    {
        try
        {
            var medicalRecordToBeDeleted = await _iSender.Send(new GetMedicalRecordByIdQuery(id));
            if (medicalRecordToBeDeleted is null)
            {
                return NotFound();
            }

            await _iSender.Send(new DeleteMedicalRecordCommand(medicalRecordToBeDeleted));
            return NoContent();
        }
        catch (Exception e)
        {
            throw new Exception($"{e.Message}");
        }
    }
}

