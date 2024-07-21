using System.ComponentModel.DataAnnotations;

namespace MediTrack.Domain.Entities
{
    public class Physician
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public DateOnly BirthDate { get; set; }

        public string? Address { get; set; }

        [Required]
        public string? Phone { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Document { get; set; }

        [Required]
        public string? CRM { get; set; }
    }
}
