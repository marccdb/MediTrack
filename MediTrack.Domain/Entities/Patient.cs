using System.ComponentModel.DataAnnotations;

    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required]
        public string PatientName { get; set; }

        public DateOnly DataNascimento {get; set;}

        public string Address { get; set; }

        public string Profession { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Document { get; set; }
    }
