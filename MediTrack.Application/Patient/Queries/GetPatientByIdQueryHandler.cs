using MediatR;
using MediTrack.Domain.Entities;
using MediTrack.Domain.Repositories;

namespace MediTrack.Application;

public class GetPlayerByIdQueryHandler(IPatientRepository patientRepository) : IRequestHandler<GetPatientByIdQuery, Patient?>
{

    private readonly IPatientRepository _patientRepository = patientRepository;

    public async Task<Patient?> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _patientRepository.GetDataByIdAsync(request.id);
        return response;
    }
}
