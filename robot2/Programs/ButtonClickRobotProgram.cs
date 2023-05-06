﻿using Robot.Infrastructure.BrickPi.Movement;
using Robot.Infrastructure.BrickPi.Sensors;
using robot2.Models;
using robot2.Models.Enums;

namespace robot2.Programs
{
    public class ButtonClickRobotProgram : Models.RobotProgram, IButtonClickRobotProgram
    {
        private IMotorFactory _motorFactory;
        private ISensorFactory _sensorFactory;

        public ButtonClickRobotProgram(IMotorFactory motorFactory, ISensorFactory sensorFactory) : base()
        {
            _motorFactory = motorFactory;
            _sensorFactory = sensorFactory;
        }

        public override void ConfigureProgram()
        {
            var button = _sensorFactory.CreateTouchSensor(SensorPorts.S1);
            var motor = _motorFactory.CreateMotor(MotorPorts.MA);
            var startCommand = Command.Create("motor1", motor, (motor) => motor.Start(Direction.Forward));
            var stopCommand = Command.Create("motor1", motor, (motor) => motor.Stop());
            
            AddCondition(new Condition(
                "ButtonPressed", 
                ConditionType.ContinuousEvaluation,
                button,
                (button) => ((TouchSensor)button).IsPressed() && ((TouchSensor)button).ValueHasChanged(),
                startCommand
            ));

            AddCondition(new Condition(
                "ButtonReleased",
                ConditionType.ContinuousEvaluation,
                button,
                (button) => !((TouchSensor)button).IsPressed() && ((TouchSensor)button).ValueHasChanged(),
                stopCommand
            ));
        }
    }
}
