using MediatR;
using MediTrack.Domain.Entities;
using MediTrack.Domain.Repositories;

namespace MediTrack.Application;

public class GetPhysicianQueryHandler(IPhysicianRepository physicianRepository) : IRequestHandler<GetPhysicianQuery, IEnumerable<Physician?>>
{

    private readonly IPhysicianRepository _physicianRepository = physicianRepository;

    public async Task<IEnumerable<Physician?>> Handle(GetPhysicianQuery request, CancellationToken cancellationToken)
    {
        var response = await _physicianRepository.GetAllDataAsync();
        return response;
    }
}
