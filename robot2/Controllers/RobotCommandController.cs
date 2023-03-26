using Microsoft.AspNetCore.Mvc;

namespace robot2.Controllers;

[ApiController]
[Route("[controller]")]
public class RobotCommandController : ControllerBase
{

    private readonly ILogger<RobotCommandController> _logger;

    public RobotCommandController(ILogger<RobotCommandController> logger)
    {
        _logger = logger;
    }


}
