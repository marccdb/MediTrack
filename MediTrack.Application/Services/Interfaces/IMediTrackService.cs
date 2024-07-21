
namespace MediTrack.Application.Services.Interfaces
{
    public interface IMediTrackService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllDataAsync();

        Task<T> GetDataByIdAsync(int id);

        Task RegisterNewAsync(T entity);

        Task UpdateExistingAsync(int id, T entity);

        Task DeleteExistingAsync(int id);

    }
}
