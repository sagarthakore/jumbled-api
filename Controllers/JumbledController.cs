using Microsoft.AspNetCore.Mvc;
using Jumbled_API.Services;

namespace Jumbled_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JumbledController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string word)
        {
            if (string.IsNullOrEmpty(word)) 
            {
                return BadRequest();
            }    
            return Ok(new Jumbled().GetDictionaryWords(word));
        }
    }
}
