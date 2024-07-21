using MediTrack.Domain.Entities;
using System.ComponentModel.DataAnnotations;


public class MedicalRecord
{
    [Key]
    public int MedicalRecordId { get; set; }

    [Required]
    public Patient? PatientId { get; set; }

    [Required]
    public Physician? PhysicianId { get; set; }

    [Required]
    public string? PatientName { get; set; }

    public string? SessionSummary { get; set; }

    [Required]
    public bool Paid { get; set; }

    [Required]
    public DateTime SessionDate { get; set; }

    public string? Comments { get; set; }

}
