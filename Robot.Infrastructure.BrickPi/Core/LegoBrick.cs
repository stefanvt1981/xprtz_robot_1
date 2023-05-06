using Iot.Device.BrickPi3;

namespace Robot.Infrastructure.BrickPi.Core
{
    public class LegoBrick : ILegoBrick
    {
        private Brick _brick;
        
        public LegoBrick() 
        { 
            _brick= new Brick(1);
        }

        public Brick GetBrick()
        {
            return _brick;
        }

        public void PrintInfo()
        {
            var brickinfo = _brick.BrickPi3Info;
            Console.WriteLine($"Manufacturer: {brickinfo.Manufacturer}");
            Console.WriteLine($"Board: {brickinfo.Board}");
            Console.WriteLine($"Hardware version: {brickinfo.HardwareVersion}");
        }
    }
}
