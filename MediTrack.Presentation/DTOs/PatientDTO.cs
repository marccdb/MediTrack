using System.ComponentModel.DataAnnotations;

namespace MediTrack.Presentation.DTOs;

public class PatientDTO
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateOnly BirthDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    public string? Address { get; set; }

    public string? Profession { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Document { get; set; }
}
