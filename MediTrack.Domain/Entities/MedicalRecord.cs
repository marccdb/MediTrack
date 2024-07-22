using System.ComponentModel.DataAnnotations;

namespace MediTrack.Domain.Entities
{
    public class MedicalRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Patient? Patient { get; set; }

        [Required]
        public Physician? Physician { get; set; }

        public string? SessionSummary { get; set; }

        [Required]
        public bool Paid { get; set; } = false;

        [Required]
        public DateTime SessionDate { get; set; }

        public string? Comments { get; set; }

    }
}

