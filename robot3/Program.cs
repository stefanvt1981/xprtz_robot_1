using Microsoft.Extensions.DependencyInjection;
using Robot.Infrastructure.BrickPi;
using Robot.Infrastructure.BrickPi.Core;

var builder = new ServiceCollection()
    .AddBrickPi()
    .BuildServiceProvider();

var legoBrick = builder.GetRequiredService<ILegoBrick>();

legoBrick.PrintInfo();
