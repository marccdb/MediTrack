
using MediTrack.Infrastructure.Persistance.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTrack.Infrastructure.Persistance.MediTrackRepo
{
    public class MediTrackRepo<T>(MediTrackContext context) : IMediTrackRepo<T> where T : class
    {

        private readonly MediTrackContext _context = context;

        public async Task DeleteExistingAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllDataAsync()
        {
            var result = await _context.Set<T>().AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<T> GetDataByIdAsync(int id)
        {
            var result = await _context.Set<T>().FindAsync(id);
            return result;
        }

        public async Task CreateNewAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            _context.SaveChanges();
        }

        public async Task UpdateExistingAsync(int id, T entity)
        {

            _context.Entry(entity).State = EntityState.Modified;

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
