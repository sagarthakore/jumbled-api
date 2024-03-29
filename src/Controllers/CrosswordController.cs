namespace Jumbled_API.Controllers;

[ApiController]
[Route("[controller]")]
public class CrosswordController(IJumbledService jumbledService) : ControllerBase
{
    private readonly IJumbledService _jumbledService = jumbledService;

    [HttpGet]
    public IActionResult Get([FromQuery]string word, [FromQuery]string exclude, [FromQuery]string include)
    {
        if (string.IsNullOrEmpty(word))
        {
            return BadRequest();
        }
        return Ok(_jumbledService.GetWordGuess(word, exclude, include));
    }
}
