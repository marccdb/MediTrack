using MediTrack.Infrastructure.Persistance.Interfaces;

namespace MediTrack.Infrastructure.Persistance.PatientPersist
{
    public class PatientRepo : IMediTrackRepo<Patient>
    {

        public Task DeleteExistingAsync(Patient entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Patient>> GetAllDataAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Patient> GetDataByIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task RegisterNewAsync(Patient entity)
        {
            throw new NotImplementedException();
        }

        public void SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateExistingAsync(Patient entity)
        {
            throw new NotImplementedException();
        }
    }
}
