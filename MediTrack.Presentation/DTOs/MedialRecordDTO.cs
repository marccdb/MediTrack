namespace MediTrack.Presentation.DTOs;

public class MedialRecordDTO
{
    public int PatientId { get; set; }

    public int PhysicianId { get; set; }

    public string? SessionSummary { get; set; }

    public bool Paid { get; set; } = false;

    public DateTime SessionDate { get; set; } = DateTime.Now;

    public string? Comments { get; set; }
}
