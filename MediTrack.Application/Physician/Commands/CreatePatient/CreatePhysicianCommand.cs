using MediatR;

namespace MediTrack.Application;

public record CreatePhysicianCommand(string FirstName, string LastName, DateOnly BirthDate, string Address, string Phone, string Email, string Document, string CRM) : IRequest<int>;
