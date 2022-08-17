using Microsoft.AspNetCore.Mvc;
using Jumbled_API.Services.Interfaces;

namespace Jumbled_API.Controllers;

[ApiController]
[Route("[controller]")]
public class JumbledController : ControllerBase
{
    private readonly IJumbledService _jumbledService;

    public JumbledController(IJumbledService jumbledService)
    {
        _jumbledService = jumbledService;
    }

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
