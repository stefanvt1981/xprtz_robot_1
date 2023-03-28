using Microsoft.Extensions.DependencyInjection;
using Robot.Infrastructure.BrickPi.Core;

namespace Robot.Infrastructure.BrickPi
{
    public static class ServiceRegistration
    {
        public static void AddBrickPi(this IServiceCollection services) 
        {
            services.AddSingleton<LegoBrick>();
        }
    }
}
