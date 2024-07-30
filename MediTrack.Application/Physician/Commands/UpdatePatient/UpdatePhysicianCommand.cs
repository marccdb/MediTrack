using MediatR;

namespace MediTrack.Application;

public record UpdatePhysicianCommand(int id, string firstName, string lastName, DateOnly birthDate, string address, string profession, string phone, string email, string document, string CRM) : IRequest<int>
{

}
