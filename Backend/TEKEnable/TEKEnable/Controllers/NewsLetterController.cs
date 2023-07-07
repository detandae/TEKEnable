using Microsoft.AspNetCore.Mvc;
using TEKEnable.Models;

namespace TEKEnable.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsLetterController : ControllerBase
    {
        private readonly ILogger<NewsLetterController> _logger;

        public NewsLetterController(ILogger<NewsLetterController> logger)
        {
            _logger = logger;
        }

        [HttpPost("AddNewsLetter")]

        public async Task<IActionResult> AddNewsLetter([FromBody] SignUpDetails signUpDetails)
        {
            return Ok();
        }
    }
}