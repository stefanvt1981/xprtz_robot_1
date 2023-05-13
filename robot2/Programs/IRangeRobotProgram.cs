using Robot.Infrastructure.BrickPi.Movement;
using robot2.Models;

namespace robot2.Programs;

public interface IRangeRobotProgram
{
    void ConfigureProgram();
    void AddCommand(Command command);
    void AddCondition(Condition condition);
    List<Command> GetCommands { get; }
    List<Condition> GetConditions { get; }
    List<Motor> GetMotors { get; }
}