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
            var data = await _mediTrackService.GetAllDataAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicalRecordById(int id)
        {
            var data = await _mediTrackService.GetDataByIdAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewMedicalRecord(MedicalRecord medicalRecord)
        {
            await _mediTrackService.RegisterNewAsync(medicalRecord);
            return CreatedAtAction(nameof(GetMedicalRecordById), new { id = medicalRecord.Id }, medicalRecord);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedicalRecord(int id, MedicalRecord medicalRecord)
        {
            await _mediTrackService.UpdateExistingAsync(id, medicalRecord);
            return CreatedAtAction(nameof(GetMedicalRecordById), new { id = medicalRecord.Id }, medicalRecord);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicalRecords(int id)
        {
            await _mediTrackService.DeleteExistingAsync(id);
            return Accepted();
        }














    }

}