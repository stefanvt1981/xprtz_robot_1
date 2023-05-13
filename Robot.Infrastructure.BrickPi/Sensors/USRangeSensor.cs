using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iot.Device.BrickPi3;
using Iot.Device.BrickPi3.Models;
using BrickPi3 = Iot.Device.BrickPi3.Sensors;

namespace Robot.Infrastructure.BrickPi.Sensors
{
    public class USRangeSensor : ISensor
    {
        private BrickPi3.EV3UltraSonicSensor _sensor;
        private Brick _brick;
        private SensorPort _port;

        public USRangeSensor(BrickPi3.EV3UltraSonicSensor ev3UltraSonicSensor, Brick brick, SensorPort port)
        {
            _sensor = ev3UltraSonicSensor;
            _sensor.Mode = BrickPi3.UltraSonicMode.Centimeter;
            _brick = brick;
            _port = port;
        }

        public int GetValue()
        {
            return GetDistance();
        }

        public int GetDistance()
        {
            var rangeByte = _brick.GetSensor((byte)_port);
            var rangeInCm = Convert.ToInt32(rangeByte);
            if(rangeInCm == 255) rangeInCm = 0;
            return rangeInCm;
        }

        public bool ValueHasChanged()
        {
            throw new NotImplementedException();
        }
    }
}
