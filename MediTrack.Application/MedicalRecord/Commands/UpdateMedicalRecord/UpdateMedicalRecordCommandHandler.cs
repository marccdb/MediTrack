using MediatR;
using MediTrack.Domain.Entities;
using MediTrack.Domain.Repositories;

namespace MediTrack.Application;

public class UpdateMedicalRecordCommandHandler(IMedicalRecordRepository medicalRecordRepository) : IRequestHandler<UpdateMedicalRecordCommand, int>
{
    private readonly IMedicalRecordRepository _medicalRecordRepository = medicalRecordRepository;

    public async Task<int> Handle(UpdateMedicalRecordCommand request, CancellationToken cancellationToken)
    {

        var updatedMedicalRecord = new MedicalRecord
        {
            PatientId = request.patientId,
            PhysicianId = request.physicianId,
            SessionSummary = request.sessionSummary,
            Paid = request.paid,
            SessionDate = request.sessionDate,
            Comments = request.comments
        };

        return await _medicalRecordRepository.UpdateExistingAsync(request.id, updatedMedicalRecord);


    }
}
