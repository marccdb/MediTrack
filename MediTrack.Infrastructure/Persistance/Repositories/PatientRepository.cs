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

        public async Task<int> UpdateExistingAsync(int id, Patient patient)
        {
            return await _context.Patients.Where(model => model.Id == id)
            .ExecuteUpdateAsync(entity => entity
            .SetProperty(p => p.FirstName, patient.FirstName)
            .SetProperty(p => p.LastName, patient.LastName)
            .SetProperty(p => p.BirthDate, patient.BirthDate)
            .SetProperty(p => p.Address, patient.Address)
            .SetProperty(p => p.Profession, patient.Profession)
            .SetProperty(p => p.Phone, patient.Phone)
            .SetProperty(p => p.Email, patient.Email)
            .SetProperty(p => p.Document, patient.Document));

        }
    }
}
