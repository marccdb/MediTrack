using MediatR;
using MediTrack.Domain.Repositories;

namespace MediTrack.Application;

public class DeletePhysicianCommandHandler(IPhysicianRepository physicianRepository) : IRequestHandler<DeletePhysicianCommand>
{
    private readonly IPhysicianRepository _physicianRepository = physicianRepository;

    public async Task Handle(DeletePhysicianCommand request, CancellationToken cancellationToken)
    {
        await _physicianRepository.DeleteExistingAsync(request.physician);
    }
}
