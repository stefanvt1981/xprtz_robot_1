using Robot.Infrastructure.BrickPi.Movement;

namespace robot2.Models
{
    public class Command
    {
        private string _name;
        private readonly IMotor _motor;
        private readonly Action<IMotor> _commandAction;

        private Command(string name, IMotor motor, Action<IMotor> commandAction)
        {
            _name = name;
            _motor = motor;
            _commandAction = commandAction;
        }

        public static Command Create(string name, IMotor motor, Action<IMotor> commandAction)
        {
            return new Command(name, motor, commandAction);
        }

        public string Name => _name;

        public void Execute()
        {
            _commandAction.Invoke(_motor);
        }
    }
}
