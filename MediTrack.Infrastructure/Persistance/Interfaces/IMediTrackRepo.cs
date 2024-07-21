
namespace MediTrack.Infrastructure.Persistance.Interfaces
{
    internal interface IMediTrackRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAllDataAsync();

        Task<T> GetDataByIdAsync();

        Task RegisterNewAsync(T entity);

        Task UpdateExistingAsync(T entity);

        Task DeleteExistingAsync(T entity);

        void SaveAsync();


    }
}
