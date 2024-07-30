using MediatR;
using MediTrack.Domain.Entities;
using MediTrack.Domain.Repositories;

namespace MediTrack.Application;

public class UpdatePhysicianCommandHandler(IPhysicianRepository physicianRepository) : IRequestHandler<UpdatePhysicianCommand, int>
{
    private readonly IPhysicianRepository _physicianRepository = physicianRepository;

    public async Task<int> Handle(UpdatePhysicianCommand request, CancellationToken cancellationToken)
    {

        var updatedPhysician = new Physician
        {
            FirstName = request.firstName,
            LastName = request.lastName,
            BirthDate = request.birthDate,
            Address = request.address,
            Phone = request.phone,
            Email = request.email,
            Document = request.document,
            CRM = request.CRM
        };

        return await _physicianRepository.UpdateExistingAsync(request.id, updatedPhysician);


    }
}
