using MediatR;
using MediTrack.Domain.Entities;
using MediTrack.Domain.Repositories;

namespace MediTrack.Application;

public class UpdatePatientCommandHandler(IPatientRepository patientRepository) : IRequestHandler<UpdatePatientCommand, int>
{
    private readonly IPatientRepository _patientRepository = patientRepository;

    public async Task<int> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {

        var updatedPatient = new Patient
        {
            FirstName = request.firstName,
            LastName = request.lastName,
            BirthDate = request.birthDate,
            Address = request.address,
            Profession = request.profession,
            Phone = request.phone,
            Email = request.email,
            Document = request.document
        };

        return await _patientRepository.UpdateExistingAsync(request.id, updatedPatient);


    }
}
