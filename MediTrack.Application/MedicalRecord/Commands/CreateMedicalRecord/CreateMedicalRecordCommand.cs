using MediatR;

namespace MediTrack.Application;

public record CreateMedicalRecordCommand(int PatientId, int PhysicianId, string SessionSummary, bool Paid, DateTime SessionDate, string? Comments) : IRequest<int>;
