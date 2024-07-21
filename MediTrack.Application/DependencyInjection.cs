using MediTrack.Application.Services;
using MediTrack.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MediTrack.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddScoped(typeof(IMediTrackService<>), typeof(MediTrackService<>));

            return services;
        }

    }
}
