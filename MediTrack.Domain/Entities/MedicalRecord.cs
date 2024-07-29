using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediTrack.Domain.Entities
{
    public class MedicalRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("PatientId")]
        public int PatientId { get; set; }

        [Required]
        [ForeignKey("PhysicianId")]
        public int PhysicianId { get; set; }

        public string? SessionSummary { get; set; }

        [Required]
        public bool Paid { get; set; } = false;

        [Required]
        public DateTime SessionDate { get; set; } = DateTime.Now;

        public string? Comments { get; set; }

    }
}

