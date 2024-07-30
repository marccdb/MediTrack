using MediatR;
using MediTrack.Domain.Repositories;

namespace MediTrack.Application;

public class DeleteMedicalRecordCommandHandler(IMedicalRecordRepository medicalRecordRepository) : IRequestHandler<DeleteMedicalRecordCommand>
{
    private readonly IMedicalRecordRepository _medicalRecordRepository = medicalRecordRepository;

    public async Task Handle(DeleteMedicalRecordCommand request, CancellationToken cancellationToken)
    {
        await _medicalRecordRepository.DeleteExistingAsync(request.medicalRecord);
    }
}
