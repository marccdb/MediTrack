using MediTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediTrack.Infrastructure.Persistance
{
    public class MediTrackContext : DbContext
    {

        public MediTrackContext(DbContextOptions<MediTrackContext> options) : base(options) { }  
        

        public DbSet<Physician> Physicians { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<MedicalRecord> MedicalRecords { get; set; }



    }
}
