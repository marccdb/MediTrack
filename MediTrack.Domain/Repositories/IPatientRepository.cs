using MediTrack.Domain.Entities;

namespace MediTrack.Domain.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllDataAsync();

        Task<Patient> GetDataByIdAsync(int id);

        Task CreateNewAsync(Patient patient);

        Task UpdateExistingAsync(Patient patient);

        Task DeleteExistingAsync(Patient patient);


    }
}
