
namespace MediTrack.Infrastructure.Persistance.Interfaces
{
    public interface IMediTrackRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAllDataAsync();

        Task<T> GetDataByIdAsync(int id);

        Task CreateNewAsync(T entity);

        Task UpdateExistingAsync(T entity);

        Task DeleteExistingAsync(T entity);


    }
}
