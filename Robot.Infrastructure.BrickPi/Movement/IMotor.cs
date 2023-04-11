namespace Robot.Infrastructure.BrickPi.Movement;

public interface IMotor
{
    void Start();
    void Start(Direction direction);
    void Reverse();
    void Stop();
}