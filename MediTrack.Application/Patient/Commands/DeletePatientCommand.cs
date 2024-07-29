using MediatR;
using MediTrack.Domain.Entities;

namespace MediTrack.Application;

public record DeletePatientCommand(Patient patient) : IRequest
{

}
