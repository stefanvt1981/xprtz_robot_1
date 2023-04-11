using BrickPi3 = Iot.Device.BrickPi3.Sensors;

namespace Robot.Infrastructure.BrickPi.Sensors
{
    public class TouchSensor : ISensor
    {
        private BrickPi3.EV3TouchSensor _sensor;
        private bool _isPressed = false;
        private bool _hasChanged = false;

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
            var isPressed = _sensor.IsPressed();

            if (isPressed != _isPressed)
            {
                _isPressed = isPressed;
                _hasChanged = true;
            }
            else
            {
                _hasChanged = false;
            }

            return isPressed;
        }

        public bool ValueHasChanged()
        {
            return _hasChanged;
        }
    }
}
