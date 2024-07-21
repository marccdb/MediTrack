using System.ComponentModel.DataAnnotations;

namespace MediTrack.Domain.Entities
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastNameName { get; set; }

        public DateOnly BirthDate { get; set; }

        public string? Address { get; set; }

        public string? Profession { get; set; }
        [Required]
        public string? Phone { get; set; }

        public string? Email { get; set; }
        [Required]
        public string? Document { get; set; }
    }
}

