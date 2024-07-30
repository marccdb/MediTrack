using MediatR;
using MediTrack.Domain.Entities;
using MediTrack.Domain.Repositories;

namespace MediTrack.Application;

public class GetMedicalRecordQueryHandler(IMedicalRecordRepository medicalRecordRepository) : IRequestHandler<GetMedicalRecordQuery, IEnumerable<MedicalRecord?>>
{

    private readonly IMedicalRecordRepository _medicalRecordRepository = medicalRecordRepository;

    public async Task<IEnumerable<MedicalRecord?>> Handle(GetMedicalRecordQuery request, CancellationToken cancellationToken)
    {
        var response = await _medicalRecordRepository.GetAllDataAsync();
        return response;
    }
}
