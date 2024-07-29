using Microsoft.Extensions.DependencyInjection;
using MediTrack.Domain.Repositories;
using MediTrack.Infrastructure.Persistance.Repositories;

namespace MediTrack.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPhysicianRepository, PhysicianRepository>();
            services.AddScoped<IMedicalRecordRepository, MedicalRecordRepository>();

            return services;
        }

    }
}
