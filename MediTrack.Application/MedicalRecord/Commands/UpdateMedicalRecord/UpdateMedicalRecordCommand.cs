using MediatR;

namespace MediTrack.Application;

public record UpdateMedicalRecordCommand(int id, int patientId, int physicianId, string? sessionSummary, bool paid, DateTime sessionDate, string? comments) : IRequest<int>
{

}
