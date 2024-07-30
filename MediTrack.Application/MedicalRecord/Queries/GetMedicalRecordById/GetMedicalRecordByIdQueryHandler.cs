using MediatR;
using MediTrack.Domain.Entities;
using MediTrack.Domain.Repositories;

namespace MediTrack.Application;

public class GetMedicalRecordByIdQueryHandler(IMedicalRecordRepository medicalRecordRepository) : IRequestHandler<GetMedicalRecordByIdQuery, MedicalRecord?>
{

    private readonly IMedicalRecordRepository _medicalRecordRepository = medicalRecordRepository;

    public async Task<MedicalRecord?> Handle(GetMedicalRecordByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _medicalRecordRepository.GetDataByIdAsync(request.id);
        return response;
    }
}
