using Motors = Iot.Device.BrickPi3.Movement;
using Iot.Device.BrickPi3.Models;
using Robot.Infrastructure.BrickPi.Core;

namespace Robot.Infrastructure.BrickPi.Movement
{
    public class MotorFactory : IMotorFactory
    {
        private ILegoBrick _brick;

        public MotorFactory(ILegoBrick brick) 
        { 
            _brick= brick;
        }

        public Motor CreateMotor(MotorPorts port)
        {
            var ev3Motor = new Motors.Motor(_brick.GetBrick(), MapMotorPort(port));
            return new Motor(ev3Motor);
        }

        private static BrickPortMotor MapMotorPort(MotorPorts port) => port switch
        {
            MotorPorts.MA => BrickPortMotor.PortA,
            MotorPorts.MB => BrickPortMotor.PortB,
            MotorPorts.MC => BrickPortMotor.PortC,
            MotorPorts.MD => BrickPortMotor.PortD,
            _ => throw new ArgumentException($"Invalid motorport {port}")
        };
    }
}
