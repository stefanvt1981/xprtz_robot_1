using robot2.DataStructures;

namespace robot2.BackgroundTasks;

public class RobotLoop : BackgroundService
{
    private CommandQueue _commandQueue;

    public RobotLoop()
    {
        _commandQueue = CommandQueue.CreateQueue();
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("RobotLoop started");
        return base.StartAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("RobotLoop executing");
        while (!stoppingToken.IsCancellationRequested)
        {
            // execute next command
            _commandQueue.RunNextCommand();

            await Task.Delay(100, stoppingToken);

            // process conditions
            _commandQueue.ProcessConditions();

            await Task.Delay(100, stoppingToken);
        }
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("RobotLoop stopped");
        return base.StopAsync(cancellationToken);
    }
}