using MediTrack.Domain.Entities;

namespace MediTrack.Domain.Repositories
{
    public interface IMedicalRecordRepository
    {
        Task<IEnumerable<MedicalRecord>> GetAllDataAsync();

        Task<MedicalRecord> GetDataByIdAsync(int id);

        Task CreateNewAsync(MedicalRecord medicalRecord);

        Task UpdateExistingAsync(int id, MedicalRecord medicalRecord);

        Task DeleteExistingAsync(MedicalRecord medicalRecord);

    }
}
