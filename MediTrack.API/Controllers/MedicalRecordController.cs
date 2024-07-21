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















    }

}