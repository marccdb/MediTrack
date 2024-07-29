using MediatR;
using MediTrack.Domain.Repositories;

namespace MediTrack.Application;

public class DeletePatientCommandHandler(IPatientRepository patientRepository) : IRequestHandler<DeletePatientCommand>
{
    private readonly IPatientRepository _patientRepository = patientRepository;

    public async Task Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        await _patientRepository.DeleteExistingAsync(request.patient);
    }
}
