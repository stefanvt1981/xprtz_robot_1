using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace robot2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RobotConditionController : ControllerBase
    {
        private readonly ILogger<RobotConditionController> _logger;

        public RobotConditionController(ILogger<RobotConditionController> logger)
        {
            _logger = logger;
        }
    }
}
