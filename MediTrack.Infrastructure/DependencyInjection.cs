using MediTrack.Infrastructure.Persistance;
using MediTrack.Infrastructure.Persistance.Interfaces;
using MediTrack.Infrastructure.Persistance.MediTrackRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MediTrack.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddScoped(typeof(IMediTrackRepo<>), typeof(MediTrackRepo<>));

            return services;
        }

    }
}
