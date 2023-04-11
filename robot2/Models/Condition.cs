using Robot.Infrastructure.BrickPi.Sensors;
using robot2.DataStructures;
using robot2.Models.Enums;

namespace robot2.Models
{
    public class Condition
    {
        private readonly string _name;
        private readonly ConditionType _type;
        private readonly ISensor _sensor;
        private readonly Func<ISensor, bool> _condition;
        private readonly Command _commandToExecute;

        public Condition(string name, ConditionType type, ISensor sensor, Func<ISensor, bool> condition, Command commandToExecute)
        {
            _name = name;
            _type = type;
            _sensor = sensor;
            _condition = condition;
            _commandToExecute = commandToExecute;
        }

        public string Name => _name;

        public ConditionType Type => _type;

        public bool EvaluateConditionTriggered(out Command? command2Execute)
        {
            if (_condition(_sensor))
            {
                command2Execute = _commandToExecute;
                return true;
            }

            command2Execute = null;
            return false;
        }
    }
}
