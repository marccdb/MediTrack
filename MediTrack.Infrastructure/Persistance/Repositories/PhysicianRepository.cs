using MediTrack.Domain.Entities;
using MediTrack.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MediTrack.Infrastructure.Persistance.Repositories
{
    public class PhysicianRepository(ApplicationDbContext context) : IPhysicianRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task DeleteExistingAsync(Physician physician)
        {
            _context.Remove(physician);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Physician>> GetAllDataAsync()
        {
            var result = await _context.Set<Physician>().AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<Physician> GetDataByIdAsync(int id)
        {
            var result = await _context.Set<Physician>().FindAsync(id);
            return result;
        }

        public async Task CreateNewAsync(Physician physician)
        {
            await _context.Set<Physician>().AddAsync(physician);
            _context.SaveChanges();
        }

        public async Task<int> UpdateExistingAsync(int id, Physician physician)
        {
            return await _context.Physicians.Where(model => model.Id == id)
            .ExecuteUpdateAsync(entity => entity
            .SetProperty(p => p.FirstName, physician.FirstName)
            .SetProperty(p => p.LastName, physician.LastName)
            .SetProperty(p => p.BirthDate, physician.BirthDate)
            .SetProperty(p => p.Address, physician.Address)
            .SetProperty(p => p.Phone, physician.Phone)
            .SetProperty(p => p.Email, physician.Email)
            .SetProperty(p => p.Document, physician.Document)
            .SetProperty(p => p.CRM, physician.CRM));
        }
    }
}
