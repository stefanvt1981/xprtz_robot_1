using Microsoft.Extensions.DependencyInjection;
using Robot.Infrastructure.BrickPi;
using Robot.Infrastructure.BrickPi.Core;
using Robot.Infrastructure.BrickPi.Movement;
using Robot.Infrastructure.BrickPi.Sensors;

var builder = new ServiceCollection()
    .AddBrickPi()
    .BuildServiceProvider();

var legoBrick = builder.GetRequiredService<ILegoBrick>();
var mf = builder.GetRequiredService<IMotorFactory>();
var sf = builder.GetRequiredService<ISensorFactory>();

var motor = mf.CreateMotor(MotorPorts.MA);
var touch = sf.CreateTouchSensor(SensorPorts.S1);

int count = 0;
bool pressed = false;

while (count < 1000)
{
    count++;
    if (touch.IsPressed() && !pressed)
    {
        Console.WriteLine("start!");
        motor.Start(Direction.Forward);
        pressed = true;
    }
    else if (!touch.IsPressed() && pressed)
    {
        Console.WriteLine("stop!");
        motor.Stop();
        pressed = false;
    }
    else
    {
        // nothing yet
    }
    await Task.Delay(50);
}

legoBrick.PrintInfo();
