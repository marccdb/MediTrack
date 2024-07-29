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

        public async Task UpdateExistingAsync(int id, Physician physician)
        {

            _context.Entry(physician).State = EntityState.Modified;

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
