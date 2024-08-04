using System.ComponentModel.DataAnnotations;

namespace MediTrack.Presentation.DTOs;

public class PhysicianDTO
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateOnly BirthDate { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Document { get; set; }

    public string? CRM { get; set; }
}
