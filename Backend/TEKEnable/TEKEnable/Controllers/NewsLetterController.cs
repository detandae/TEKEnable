using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TEKEnable.Models;
using TEKEnable.Services;

namespace TEKEnable.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsLetterController : ControllerBase
    {
        private readonly ILogger<NewsLetterController> _logger;
        private readonly INewsLetterService _newsLetterService;
        public NewsLetterController(ILogger<NewsLetterController> logger, INewsLetterService newsLetterService)
        {
            _logger = logger;
            _newsLetterService = newsLetterService;
        }

        [HttpPost("SignUp")]

        public async Task<IActionResult> AddNewsLetter([FromBody] SignUpDetails newSignUpDetails)
        {
            try
            {
                _logger.LogInformation(newSignUpDetails.ToString());
                var validationResult = await _newsLetterService.ValidateSignUpDetails(newSignUpDetails);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.ErrorMessage);
                }
                await _newsLetterService.SaveSignUpDetails(newSignUpDetails);
                return Ok(newSignUpDetails);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }
}