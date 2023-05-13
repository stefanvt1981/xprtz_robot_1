using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrickPi3 = Iot.Device.BrickPi3.Sensors;

namespace Robot.Infrastructure.BrickPi.Sensors
{
    public class USRangeSensor : ISensor
    {
        private BrickPi3.EV3UltraSonicSensor _sensor;

        public USRangeSensor(BrickPi3.EV3UltraSonicSensor ev3UltraSonicSensor)
        {
            _sensor = ev3UltraSonicSensor;
        }

        public int GetValue()
        {
            return _sensor.Value;
        }

        public int GetDistance()
        {
            return _sensor.Read();
        }

        public bool ValueHasChanged()
        {
            throw new NotImplementedException();
        }
    }
}
