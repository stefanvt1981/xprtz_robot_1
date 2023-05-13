using Iot.Device.BrickPi3.Models;
using SensorsEv3 = Iot.Device.BrickPi3.Sensors;
using Robot.Infrastructure.BrickPi.Core;
using Robot.Infrastructure.BrickPi.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Infrastructure.BrickPi.Sensors
{
    public class SensorFactory : ISensorFactory
    {
        private ILegoBrick _brick;

        public SensorFactory(ILegoBrick brick)
        {
            _brick = brick;
        }

        public TouchSensor CreateTouchSensor(SensorPorts port)
        {
            var ev3TouchSensor = new SensorsEv3.EV3TouchSensor(_brick.GetBrick(), MapMotorPort(port));
            return new TouchSensor(ev3TouchSensor);
        }

        public USRangeSensor CreateUSRangeSensor(SensorPorts port)
        {
            var ev3UltraSonicSensor = new SensorsEv3.EV3UltraSonicSensor(_brick.GetBrick(), MapMotorPort(port));
            return new USRangeSensor(ev3UltraSonicSensor);
        }

        private static SensorPort MapMotorPort(SensorPorts port) => port switch
        {
            SensorPorts.S1 => SensorPort.Port1,
            SensorPorts.S2 => SensorPort.Port2,
            SensorPorts.S3 => SensorPort.Port3,
            SensorPorts.S4 => SensorPort.Port4,
            _ => throw new ArgumentException($"Invalid sensorport {port}")
        };
    }
}
