using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TEKEnable.Models;

namespace TEKEnable.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsLetterController : ControllerBase
    {
        private readonly ILogger<NewsLetterController> _logger;
        private readonly TEKEnableDbContext _dbContext;

        public NewsLetterController(ILogger<NewsLetterController> logger,TEKEnableDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpPost("SignUp")]

        public async Task<IActionResult> AddNewsLetter([FromBody] SignUpDetails newSignUpDetails)
        {
            _logger.LogInformation(newSignUpDetails.ToString());
            bool isReasonValid = new[] { "advert", "wordOfMouth", "other" }.Contains(newSignUpDetails.SourceOfInformation);
            if (!isReasonValid)
            {
                return BadRequest("The SourceOfInformation field is not valid");
            }
            var signUpDetails = await _dbContext.SignUpDetails.FirstOrDefaultAsync(s => s.Email == newSignUpDetails.Email);
            if (signUpDetails != null)
            {
                return BadRequest("This email address is already signed up!");
            }
            _dbContext.SignUpDetails.Add(newSignUpDetails);
            await _dbContext.SaveChangesAsync();
            return Ok(newSignUpDetails);
        }
    }
}