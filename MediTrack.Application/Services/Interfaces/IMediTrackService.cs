﻿
namespace MediTrack.Application.Services.Interfaces
{
    public interface IMediTrackService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllDataAsync();

        Task<T> GetDataByIdAsync();

        Task RegisterNewAsync(T entity);

        Task UpdateExistingAsync(T entity);

        Task DeleteExistingAsync(T entity);

    }
}