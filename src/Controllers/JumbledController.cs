namespace Jumbled_API.Controllers;

[ApiController]
[Route("[controller]")]
public class JumbledController(IJumbledService jumbledService) : ControllerBase
{
    private readonly IJumbledService _jumbledService = jumbledService;

    [HttpGet]
    public IActionResult Get(string word)
    {
        if (string.IsNullOrEmpty(word))
        {
            return BadRequest();
        }
        return Ok(_jumbledService.GetDictionaryWords(word));
    }
}
