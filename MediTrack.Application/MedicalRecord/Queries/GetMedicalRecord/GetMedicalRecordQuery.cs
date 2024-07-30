using MediatR;
using MediTrack.Domain.Entities;

namespace MediTrack.Application;

public record GetMedicalRecordQuery : IRequest<IEnumerable<MedicalRecord>>
{ }
