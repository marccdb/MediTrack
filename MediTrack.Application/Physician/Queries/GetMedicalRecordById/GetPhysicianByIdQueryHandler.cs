using MediatR;
using MediTrack.Domain.Entities;
using MediTrack.Domain.Repositories;

namespace MediTrack.Application;

public class GetPhysicianByIdQueryHandler(IPhysicianRepository physicianRepository) : IRequestHandler<GetPhysicianByIdQuery, Physician?>
{

    private readonly IPhysicianRepository _physicianRepository = physicianRepository;

    public async Task<Physician?> Handle(GetPhysicianByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _physicianRepository.GetDataByIdAsync(request.id);
        return response;
    }
}
