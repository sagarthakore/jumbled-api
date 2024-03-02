namespace Jumbled_API.Controllers;

[ApiController]
[Route("[controller]")]
public class ScrabbleController(IScrabbleService scrabbleService) : ControllerBase
{
    private readonly IScrabbleService _scrabbleService = scrabbleService;

    [HttpGet]
    public IActionResult Get(string rack)
    {
        if (string.IsNullOrEmpty(rack))
        {
            return BadRequest();
        }
        return Ok(_scrabbleService.GetScrabbleWordsWithScores(rack));
    }
}
