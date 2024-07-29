using MediatR;

namespace MediTrack.Application;

public record CreatePatientCommand(string firstName, string lastName, DateOnly birthDate, string address, string profession, string phone, string email, string document) : IRequest<int>;
