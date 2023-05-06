using robot2.Models;
using robot2.Models.Enums;

namespace robot2.DataStructures
{
    public class CommandQueue
    {
        private Queue<Command> _queue;
        private List<Condition> _conditions;

        private CommandQueue()
        {
            _queue = new Queue<Command>();
        }

        public static CommandQueue CreateQueue()
        {
            return new CommandQueue();
        }

        public void AddCommand(Command command)
        {
            _queue.Enqueue(command);
        }

        public void RunNextCommand()
        {
            if (_queue.TryDequeue(out var command))
            {
                command.Execute();
            }
        }

        public void ProcessConditions()
        {
            var conditions2Remove = new List<Condition>();

            foreach (var condition in _conditions)
            {
                if (condition.EvaluateConditionTriggered(out var command2Execute))
                {
                    if (command2Execute == null) continue;

                    _queue.Enqueue(command2Execute);

                    if (condition.Type == ConditionType.SingleEvaluation)
                    {
                        conditions2Remove.Add(condition);
                    }
                }
            }

            foreach (var condition in conditions2Remove)
            {
                _conditions.Remove(condition);
            }
        }

        public void AddCondition(Condition condition)
        {
            _conditions.Add(condition);
        }

        public void ClearConditions()
        {
            _conditions.Clear();
        }


        public void ClearCommands()
        {
            _queue.Clear();
        }

        public void LoadProgram(RobotProgram program)
        {
            ClearCommands();
            ClearConditions();

            _conditions.AddRange(program.GetConditions);

            program.GetCommands.ForEach(command => _queue.Enqueue(command));
        }
    }
}
