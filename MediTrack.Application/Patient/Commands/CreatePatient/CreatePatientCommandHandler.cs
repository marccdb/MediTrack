using MediatR;
using MediTrack.Domain.Entities;
using MediTrack.Domain.Repositories;

namespace MediTrack.Application;

public class CreatePatientCommandHandler(IPatientRepository patientRepository) : IRequestHandler<CreatePatientCommand, int>
{

    private readonly IPatientRepository _patientRepository = patientRepository;

    public async Task<int> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = new Patient
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

        await _patientRepository.CreateNewAsync(patient);

        return patient.Id;
    }
}
