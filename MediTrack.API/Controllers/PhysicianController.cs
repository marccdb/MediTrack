using MediTrack.Application.Services.Interfaces;
using MediTrack.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MediTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhysicianController(IMediTrackService<Physician> mediTrackService) : ControllerBase
    {
        private readonly IMediTrackService<Physician>? _mediTrackService = mediTrackService;

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
        public async Task<IActionResult> GetPhysicianById(int id)
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
        public async Task<IActionResult> CreateNewPhysician(Physician physician)
        {
            if (_mediTrackService is null)
            {
                throw new Exception("Service not found");
            }

            try
            {
                await _mediTrackService.RegisterNewAsync(physician);
                return CreatedAtAction(nameof(GetPhysicianById), new { id = physician.Id }, physician);
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePhysician(int id, Physician patient)
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
        public async Task<IActionResult> DeletePhysician(int id)
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
