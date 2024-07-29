using MediTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediTrack.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }  
        

        public DbSet<Physician> Physicians { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<MedicalRecord> MedicalRecords { get; set; }

    }
}
