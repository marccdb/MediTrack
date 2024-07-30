using MediatR;
using MediTrack.Domain.Entities;

namespace MediTrack.Application;

public record DeletePhysicianCommand(Physician physician) : IRequest
{

}
