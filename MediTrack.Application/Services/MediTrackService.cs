using MediTrack.Application.Services.Interfaces;
using MediTrack.Infrastructure.Persistance.Interfaces;

namespace MediTrack.Application.Services
{
    public class MediTrackService<T>(IMediTrackRepo<T> mediTrackRepo) : IMediTrackService<T> where T : class
    {
        private readonly IMediTrackRepo<T> _mediTrackRepo = mediTrackRepo;

        public async Task<IEnumerable<T>> GetAllDataAsync()
        {
            try
            {
                return await _mediTrackRepo.GetAllDataAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<T> GetDataByIdAsync(int id)
        {
            try
            {
                return await _mediTrackRepo.GetDataByIdAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task RegisterNewAsync(T entity)
        {
            try
            {
                await _mediTrackRepo.CreateNewAsync(entity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdateExistingAsync(int id, T entity)
        {
            try
            {
                await _mediTrackRepo.UpdateExistingAsync(id, entity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteExistingAsync(int id)
        {
            try
            {
                var entityToDelete = await _mediTrackRepo.GetDataByIdAsync(id);
                await _mediTrackRepo.DeleteExistingAsync(entityToDelete);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
