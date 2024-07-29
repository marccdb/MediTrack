using MediatR;
using MediTrack.Domain.Repositories;

namespace MediTrack.Application;

public class UpdatePatientCommandHandler(IPatientRepository patientRepository) : IRequestHandler<UpdatePatientCommand, bool>
{
    private readonly IPatientRepository _patientRepository = patientRepository;

    public Task<bool> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        _patientRepository.UpdateExistingAsync(request.patient);
        return Task.FromResult(true);
    }
}
