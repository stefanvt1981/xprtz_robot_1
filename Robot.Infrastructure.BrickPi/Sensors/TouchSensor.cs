using BrickPi3 = Iot.Device.BrickPi3.Sensors;

namespace Robot.Infrastructure.BrickPi.Sensors
{
    public class TouchSensor : ISensor
    {
        private BrickPi3.EV3TouchSensor _sensor;

        internal TouchSensor(BrickPi3.EV3TouchSensor sensor)
        {
            _sensor = sensor;
        }

        public int GetValue()
        {
            return _sensor.Value;
        }

        public bool IsPressed()
        {
            return _sensor.IsPressed();
        }
    }
}
