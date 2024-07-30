using MediatR;
using MediTrack.Domain.Entities;

namespace MediTrack.Application;

public record GetPhysicianByIdQuery(int id) : IRequest<Physician>
{

}
