namespace Robot.Infrastructure.BrickPi.Movement;

public interface IMotorFactory
{
    Motor CreateMotor(MotorPorts port);
}