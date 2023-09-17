namespace Jumbled_API.Controllers;

[ApiController]
[Route("[controller]")]
public class CrosswordController : ControllerBase
{
    private readonly IJumbledService _jumbledService;

    public CrosswordController(IJumbledService jumbledService)
    {
        _jumbledService = jumbledService;
    }

    [HttpGet]
    public IActionResult Get([FromQuery]string word, [FromQuery]string exclude, [FromQuery]string include)
    {
        if (string.IsNullOrEmpty(word))
        {
            return BadRequest();
        }
        return Ok(_jumbledService.GetWordleGuess(word, exclude, include));
    }
}
