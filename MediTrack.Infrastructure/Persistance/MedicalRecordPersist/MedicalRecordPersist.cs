using MediTrack.Infrastructure.Persistance.Interfaces;

namespace MediTrack.Infrastructure.Persistance.MedicalRecordPersist
{
    internal class MedicalRecordPersist : IMediTrackRepo<MedicalRecord>
    {

        public Task DeleteExistingAsync(MedicalRecord entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MedicalRecord>> GetAllDataAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MedicalRecord> GetDataByIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task RegisterNewAsync(MedicalRecord entity)
        {
            throw new NotImplementedException();
        }

        public void SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateExistingAsync(MedicalRecord entity)
        {
            throw new NotImplementedException();
        }
    }
}
