using MediTrack.Domain.Entities;
using MediTrack.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MediTrack.Infrastructure.Persistance.Repositories
{
    public class PatientRepository(ApplicationDbContext context) : IPatientRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task DeleteExistingAsync(Patient patient)
        {
            _context.Remove(patient);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Patient>> GetAllDataAsync()
        {
            var result = await _context.Patients.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<Patient> GetDataByIdAsync(int id)
        {
            var result = await _context.Patients.FindAsync(id);
            return result;
        }

        public async Task CreateNewAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateExistingAsync(Patient patient)
        {

            _context.Entry(patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {

                throw new DbUpdateConcurrencyException(ex.Message);
            }

        }
    }
}
