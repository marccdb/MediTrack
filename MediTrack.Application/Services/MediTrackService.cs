using MediTrack.Application.Services.Interfaces;
using MediTrack.Infrastructure.Persistance.Interfaces;

namespace MediTrack.Application.Services
{
    public class MediTrackService<T>(IMediTrackRepo<T> mediTrackRepo) : IMediTrackService<T> where T : class
    {
        private readonly IMediTrackRepo<T> _mediTrackRepo = mediTrackRepo;

        public async Task<IEnumerable<T>> GetAllDataAsync()
        {
            return await _mediTrackRepo.GetAllDataAsync();

        }

        public async Task<T> GetDataByIdAsync(int id)
        {
            return await _mediTrackRepo.GetDataByIdAsync(id);
        }

        public async Task RegisterNewAsync(T entity)
        {
            await _mediTrackRepo.CreateNewAsync(entity);
        }

        public async Task UpdateExistingAsync(int id, T entity)
        {
            var entityToUpdate = await _mediTrackRepo.GetDataByIdAsync(id);
            await _mediTrackRepo.UpdateExistingAsync(entity);

        }

        public async Task DeleteExistingAsync(int id)
        {
            var entityToDelete = await _mediTrackRepo.GetDataByIdAsync(id);
            await _mediTrackRepo.DeleteExistingAsync(entityToDelete);
        }


    }
}
