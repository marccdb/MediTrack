using MediatR;
using MediTrack.Domain.Entities;

namespace MediTrack.Application;

public record GetPhysicianQuery : IRequest<IEnumerable<Physician>>
{ }
