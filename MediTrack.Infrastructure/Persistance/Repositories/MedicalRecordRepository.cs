using MediTrack.Domain.Entities;
using MediTrack.Domain.Repositories;
using Microsoft.EntityFrameworkCore;


namespace MediTrack.Infrastructure.Persistance.Repositories
{
    public class MedicalRecordRepository(ApplicationDbContext context) : IMedicalRecordRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task DeleteExistingAsync(MedicalRecord medicalRecord)
        {
            _context.Remove(medicalRecord);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MedicalRecord>> GetAllDataAsync()
        {
            var result = await _context.Set<MedicalRecord>().AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<MedicalRecord> GetDataByIdAsync(int id)
        {
            var result = await _context.Set<MedicalRecord>().FindAsync(id);
            return result;
        }

        public async Task CreateNewAsync(MedicalRecord medicalRecord)
        {
            await _context.Set<MedicalRecord>().AddAsync(medicalRecord);
            _context.SaveChanges();
        }

        public async Task<int> UpdateExistingAsync(int id, MedicalRecord medicalRecord)
        {
            return await _context.MedicalRecords.Where(model => model.Id == id)
            .ExecuteUpdateAsync(entity => entity
            .SetProperty(p => p.PatientId, medicalRecord.PatientId)
            .SetProperty(p => p.PhysicianId, medicalRecord.PhysicianId)
            .SetProperty(p => p.SessionSummary, medicalRecord.SessionSummary)
            .SetProperty(p => p.Paid, medicalRecord.Paid)
            .SetProperty(p => p.SessionDate, medicalRecord.SessionDate)
            .SetProperty(p => p.Comments, medicalRecord.Comments));

        }
    }
}
