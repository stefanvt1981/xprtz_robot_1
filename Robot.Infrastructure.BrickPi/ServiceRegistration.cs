﻿using Microsoft.Extensions.DependencyInjection;
using Robot.Infrastructure.BrickPi.Core;
using Robot.Infrastructure.BrickPi.Movement;
using Robot.Infrastructure.BrickPi.Sensors;

namespace Robot.Infrastructure.BrickPi
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBrickPi(this IServiceCollection services) 
        {
            services.AddTransient<ILegoBrick, LegoBrick>();
            services.AddTransient<IMotorFactory, MotorFactory>();
            services.AddTransient<ISensorFactory, SensorFactory>();

            return services;
        }
    }
}
