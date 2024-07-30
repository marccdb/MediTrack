using MediatR;
using MediTrack.Domain.Entities;

namespace MediTrack.Application;

public record DeleteMedicalRecordCommand(MedicalRecord medicalRecord) : IRequest
{

}
