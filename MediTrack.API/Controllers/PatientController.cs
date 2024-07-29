using MediatR;
using MediTrack.Application;
using Microsoft.AspNetCore.Mvc;

namespace MediTrack.API.Controllers
{
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
                var data = await _iSender.Send(new GetPatientQuery());
                return Ok(data);
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
                var patient = await _iSender.Send(command);
                return Ok(patient);
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(UpdatePatientCommand command)
        {
            try
            {
                var data = await _iSender.Send(command.patient.Id);
                if (data is null)
                {
                    return NotFound();
                }

                await _iSender.Send(data);
                return Created();
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
                var data = await _iSender.Send(new GetPatientByIdQuery(id));
                if (data is null)
                {
                    return NotFound();
                }

                await _iSender.Send(new DeletePatientCommand(data));
                return Accepted();
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }
        }
    }
}
