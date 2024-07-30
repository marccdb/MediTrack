using MediatR;
using MediTrack.Domain.Entities;

namespace MediTrack.Application;

public record GetMedicalRecordByIdQuery(int id) : IRequest<MedicalRecord>
{

}
