using MediatR;
using MediTrack.Domain.Entities;

namespace MediTrack.Application;

public record GetPatientQuery : IRequest<IEnumerable<Patient>>
{ }
