using MediatR;
using MediTrack.Domain.Entities;
using MediTrack.Domain.Repositories;

namespace MediTrack.Application;

public class CreateMedicalRecordCommandHandler(IMedicalRecordRepository medicalRecordRepository) : IRequestHandler<CreateMedicalRecordCommand, int>
{

    private readonly IMedicalRecordRepository _medicalRecordRepository = medicalRecordRepository;

    public async Task<int> Handle(CreateMedicalRecordCommand request, CancellationToken cancellationToken)
    {
        var medicalRecord = new MedicalRecord
        {
            PatientId = request.PatientId,
            PhysicianId = request.PhysicianId,
            SessionSummary = request.SessionSummary,
            Paid = request.Paid,
            SessionDate = request.SessionDate,
            Comments = request.Comments
        };

        await _medicalRecordRepository.CreateNewAsync(medicalRecord);

        return medicalRecord.Id;
    }
}
