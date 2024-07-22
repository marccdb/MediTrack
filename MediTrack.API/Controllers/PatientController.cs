using MediTrack.Application.Services.Interfaces;
using MediTrack.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MediTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController(IMediTrackService<Patient> mediTrackService) : ControllerBase
    {
        private readonly IMediTrackService<Patient>? _mediTrackService = mediTrackService;

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            if (_mediTrackService is null)
            {
                throw new Exception("Service not found");
            }

            try
            {
                var data = await _mediTrackService.GetAllDataAsync();
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
            if (_mediTrackService is null)
            {
                throw new Exception("Service not found");
            }

            try
            {
                var data = await _mediTrackService.GetDataByIdAsync(id);
                if (data is null)
                {
                    return NotFound();
                }

                return Ok(data);
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewPatient(Patient patient)
        {
            if (_mediTrackService is null)
            {
                throw new Exception("Service not found");
            }

            try
            {
                await _mediTrackService.RegisterNewAsync(patient);
                return CreatedAtAction(nameof(GetPatientById), new { id = patient.Id }, patient);
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, Patient patient)
        {

            if (_mediTrackService is null)
            {
                throw new Exception("Service not found");
            }

            try
            {
                var data = await _mediTrackService.GetDataByIdAsync(id);
                if (data is null)
                {
                    return NotFound();
                }

                await _mediTrackService.UpdateExistingAsync(id, patient);
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
            if (_mediTrackService is null)
            {
                throw new Exception("Service not found");
            }

            try
            {
                var data = await _mediTrackService.GetDataByIdAsync(id);
                if (data is null)
                {
                    return NotFound();
                }
                await _mediTrackService.DeleteExistingAsync(id);
                return Accepted();
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }
        }
    }
}
