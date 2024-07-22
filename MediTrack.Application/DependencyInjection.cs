using Microsoft.Extensions.DependencyInjection;
using MediTrack.Application.Services.Interfaces;
using MediTrack.Application.Services;


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
