var builder = new ServiceCollection()
    .AddBrickPi()
    .BuildServiceProvider();

var legoBrick = builder.GetRequiredService<ILegoBrick>();

legoBrick.PrintInfo();
