namespace Jumbled_API.Controllers;

[ApiController]
[Route("[controller]")]
public class WarmupController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("ready");
    }
}
