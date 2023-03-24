using Iot.Device.BrickPi3;
using Iot.Device.BrickPi3.Sensors;
using Iot.Device.BrickPi3.Models;
using Iot.Device.BrickPi3.Movement;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Brick brick = new Brick(1);

var brickinfo = brick.BrickPi3Info;
Console.WriteLine($"Manufacturer: {brickinfo.Manufacturer}");
Console.WriteLine($"Board: {brickinfo.Board}");
Console.WriteLine($"Hardware version: {brickinfo.HardwareVersion}");

var touch = new EV3TouchSensor(brick, SensorPort.Port1);
var motor = new Motor(brick, BrickPortMotor.PortA);


int count = 0;
bool pressed = false;

while (count < 1000)
{
    count++;
    if (touch.IsPressed() && motor.)
    {
        Console.WriteLine("start!");
        motor.SetSpeed(100);
        //motor.Start();
        pressed = true;
    }
    else if(!touch.IsPressed() && pressed)
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