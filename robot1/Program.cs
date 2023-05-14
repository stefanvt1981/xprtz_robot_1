﻿using Iot.Device.BrickPi3;
using Iot.Device.BrickPi3.Sensors;
using Iot.Device.BrickPi3.Models;
using Iot.Device.BrickPi3.Movement;
using System.Text;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Brick brick = new Brick(1);

var brickinfo = brick.BrickPi3Info;
Console.WriteLine($"Manufacturer: {brickinfo.Manufacturer}");
Console.WriteLine($"Board: {brickinfo.Board}");
Console.WriteLine($"Hardware version: {brickinfo.HardwareVersion}");

var touch = new EV3TouchSensor(brick, SensorPort.Port1);
var range = new EV3UltraSonicSensor(brick, SensorPort.Port4);
var motor = new Motor(brick, BrickPortMotor.PortA);

range.Mode = Iot.Device.BrickPi3.Sensors.UltraSonicMode.Centimeter;

int count = 0;
bool pressed = false;

while (count < 1000)
{
    //Console.WriteLine($"Range: {BitConverter.ToInt64(brick.GetSensor((byte)SensorPort.Port4))}");
    Print(brick.GetSensor((byte)SensorPort.Port4));
    //Console.WriteLine($"Range: {range.ReadRaw()}");
    //count++;
    //if (touch.IsPressed() && !pressed)
    //{
    //    Console.WriteLine("start!");
    //    motor.SetSpeed(100);
    //    //motor.Start();
    //    pressed = true;
    //}
    //else if(!touch.IsPressed() && pressed)
    //{
    //    Console.WriteLine("stop!");
    //    motor.Stop();
    //    pressed = false;
    //}
    //else
    //{
    //    // nothing yet
    //}
    await Task.Delay(2000);
}

void Print(byte[] array)
{
    if (array == null)
    {
        Console.WriteLine("array is null");
        return;
    }
    //Console.WriteLine($"array length: {array.Length}");
    //Console.WriteLine($"array: {BitConverter.ToString(array)}");
    var intje = Convert.ToInt32(array[1]);
    if (intje == 255)
    {
        intje = 0;
    }
    Console.WriteLine($"Lenght in CM: {intje}");

}