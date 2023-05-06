using Iot.Device.BrickPi3;

namespace Robot.Infrastructure.BrickPi.Core;

public interface ILegoBrick
{
    Brick GetBrick();
    void PrintInfo();
}