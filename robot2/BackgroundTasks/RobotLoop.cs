using robot2.DataStructures;
using robot2.Models;
using robot2.Programs;

namespace robot2.BackgroundTasks;

public class RobotLoop : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private CommandQueue _commandQueue;

    public RobotLoop(IServiceProvider serviceProvider)
    {
        _commandQueue = CommandQueue.CreateQueue();
        _serviceProvider = serviceProvider;
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("RobotLoop started");
        return base.StartAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("RobotLoop executing");

        using (IServiceScope scope = _serviceProvider.CreateScope())
        {
            var program = scope.ServiceProvider.GetRequiredService<IButtonClickRobotProgram>();

            _commandQueue.LoadProgram((RobotProgram)program);
        }

        while (!stoppingToken.IsCancellationRequested)
        {
            // execute next command
            _commandQueue.RunNextCommand();

            await Task.Delay(10, stoppingToken);

            // process conditions
            _commandQueue.ProcessConditions();

            await Task.Delay(10, stoppingToken);
        }
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("RobotLoop stopped");
        _commandQueue.StopProgram();
        return base.StopAsync(cancellationToken);
    }
}