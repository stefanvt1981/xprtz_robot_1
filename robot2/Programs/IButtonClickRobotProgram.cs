using robot2.Models;

namespace robot2.Programs;

public interface IButtonClickRobotProgram
{
    void ConfigureProgram();
    List<Command> GetCommands { get; }
    List<Condition> GetConditions { get; }
}