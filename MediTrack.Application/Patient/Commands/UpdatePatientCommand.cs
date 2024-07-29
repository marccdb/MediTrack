using MediatR;
using MediTrack.Domain.Entities;

namespace MediTrack.Application;

public record UpdatePatientCommand(Patient patient) : IRequest<bool>
{

}
