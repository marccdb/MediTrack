using MediTrack.Domain.Entities;

namespace MediTrack.Domain.Repositories
{
    public interface IPhysicianRepository
    {
        Task<IEnumerable<Physician>> GetAllDataAsync();

        Task<Physician> GetDataByIdAsync(int id);

        Task CreateNewAsync(Physician physician);

        Task<int> UpdateExistingAsync(int id, Physician physician);

        Task DeleteExistingAsync(Physician physician);
    }
}
