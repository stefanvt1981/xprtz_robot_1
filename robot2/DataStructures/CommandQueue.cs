using robot2.Models;

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

        public CommandQueue CreateQueue()
        {
            return new CommandQueue();
        }
    }
}
