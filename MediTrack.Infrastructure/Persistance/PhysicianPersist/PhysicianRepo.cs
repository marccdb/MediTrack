using MediTrack.Domain.Entities;
using MediTrack.Infrastructure.Persistance.Interfaces;


namespace MediTrack.Infrastructure.Persistance.PhysicianPersist
{
    internal class PhysicianRepo : IMediTrackRepo<Physician>
    {

        public Task DeleteExistingAsync(Physician entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Physician>> GetAllDataAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Physician> GetDataByIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task RegisterNewAsync(Physician entity)
        {
            throw new NotImplementedException();
        }

        public void SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateExistingAsync(Physician entity)
        {
            throw new NotImplementedException();
        }
    }
}
