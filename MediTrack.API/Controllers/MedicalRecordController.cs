using MediTrack.Application.Services.Interfaces;
using MediTrack.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MediTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController(IMediTrackService<MedicalRecord> mediTrackService) : ControllerBase
    {
        private readonly IMediTrackService<MedicalRecord>? _mediTrackService = mediTrackService;

        [HttpGet]
        public async Task<IActionResult> GetAllMedicalRecords()
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
        public async Task<IActionResult> GetMedicalRecordById(int id)
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
        public async Task<IActionResult> CreateNewMedicalRecord(MedicalRecord medicalRecord)
        {
            if (_mediTrackService is null)
            {
                throw new Exception("Service not found");
            }

            try
            {
                await _mediTrackService.RegisterNewAsync(medicalRecord);
                return CreatedAtAction(nameof(GetMedicalRecordById), new { id = medicalRecord.Id }, medicalRecord);
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedicalRecord(int id, MedicalRecord medicalRecord)
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

                await _mediTrackService.UpdateExistingAsync(id, medicalRecord);
                return Created();
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicalRecords(int id)
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