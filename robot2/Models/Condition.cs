using robot2.Models.Enums;

namespace robot2.Models
{
    public class Condition
    {
        private ConditionType _type;
        private Func<bool> _condition;

        public Condition(ConditionType type, Func<bool> condition)
        {
            _type = type;
            _condition = condition;
        }

        public ConditionType Type => _type;



    }
}
