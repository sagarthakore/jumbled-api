using Microsoft.AspNetCore.Mvc;
using Jumbled_API.Services.Interfaces;

namespace Jumbled_API.Controllers
{
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
        public IActionResult Get(string word, int length)
        {
            if (string.IsNullOrEmpty(word) || length <= 0)
            {
                return BadRequest();
            }
            return Ok(_jumbledService.GetDictionaryWords(word, length));
        }
    }
}
