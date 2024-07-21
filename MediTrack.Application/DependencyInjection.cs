using Microsoft.Extensions.DependencyInjection;

namespace MediTrack.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services;
        }

    }
}
