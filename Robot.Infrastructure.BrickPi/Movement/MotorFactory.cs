using Iot.Device.BrickPi3.Models;
using Robot.Infrastructure.BrickPi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Infrastructure.BrickPi.Movement
{
    public class MotorFactory
    {
        private LegoBrick _brick;

        public MotorFactory(LegoBrick brick) 
        { 
            _brick= brick;
        }

        public Motor Create(MotorPorts port)
        {
            
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
