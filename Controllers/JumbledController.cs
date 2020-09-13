using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Jumbled_API.Services;

namespace Jumbled_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JumbledController : ControllerBase
    {
        private readonly ILogger<JumbledController> _logger;

        public JumbledController(ILogger<JumbledController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(string word)
        {
            if (string.IsNullOrEmpty(word)) 
            {
                return BadRequest();
            }    
            // return Ok(new Jumbled().GetDictionaryWords(word));
            return Ok("Hello World")
        }
    }
}
