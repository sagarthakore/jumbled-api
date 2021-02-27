using Jumbled_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Jumbled_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScrabbleController : ControllerBase
    {
        private readonly IScrabbleService _scrabbleService;

        public ScrabbleController(IScrabbleService scrabbleService)
        {
            _scrabbleService = scrabbleService;
        }

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
}
