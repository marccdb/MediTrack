using MediatR;
using MediTrack.Domain.Entities;
using MediTrack.Domain.Repositories;

namespace MediTrack.Application;

public class CreatePhysicianCommandHandler(IPhysicianRepository physicianRepository) : IRequestHandler<CreatePhysicianCommand, int>
{

    private readonly IPhysicianRepository _physicianRepository = physicianRepository;

    public async Task<int> Handle(CreatePhysicianCommand request, CancellationToken cancellationToken)
    {
        var physician = new Physician
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            BirthDate = request.BirthDate,
            Address = request.Address,
            Phone = request.Phone,
            Email = request.Email,
            Document = request.Document,
            CRM = request.CRM
        };

        await _physicianRepository.CreateNewAsync(physician);

        return physician.Id;
    }
}
