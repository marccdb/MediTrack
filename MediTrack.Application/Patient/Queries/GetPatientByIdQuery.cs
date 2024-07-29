using MediatR;
using MediTrack.Domain.Entities;

namespace MediTrack.Application;

public record GetPatientByIdQuery(int id) : IRequest<Patient>
{

}
