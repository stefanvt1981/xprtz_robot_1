namespace robot2.Models
{
    public abstract class Program
    {
        private List<Command> _startingCommands;
        private List<Condition> _conditions;

        protected Program()
        {
            _startingCommands = new List<Command>();
            _conditions = new List<Condition>();

            ConfigureProgram();
        }

        protected void AddCommand(Command command)
        {
            _startingCommands.Add(command);
        }

        protected void AddCondition(Condition condition)
        {
            _conditions.Add(condition);
        }

        public abstract void ConfigureProgram();
    }
}
