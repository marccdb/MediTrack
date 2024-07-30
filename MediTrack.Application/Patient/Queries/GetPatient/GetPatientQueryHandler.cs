using MediatR;
using MediTrack.Domain.Entities;
using MediTrack.Domain.Repositories;

namespace MediTrack.Application;

public class GetPatientQueryHandler(IPatientRepository patientRepository) : IRequestHandler<GetPatientQuery, IEnumerable<Patient?>>
{

    private readonly IPatientRepository _patientRepository = patientRepository;

    public async Task<IEnumerable<Patient?>> Handle(GetPatientQuery request, CancellationToken cancellationToken)
    {
        var response = await _patientRepository.GetAllDataAsync();
        return response;
    }
}
