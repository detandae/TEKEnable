using Microsoft.EntityFrameworkCore;
using TEKEnable.Models;

namespace TEKEnable.Services
{
    public class NewsLetterService: INewsLetterService
    {
        private readonly TEKEnableDbContext _dbContext;

        public NewsLetterService(TEKEnableDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public  async Task<ValidationResult> ValidateSignUpDetails(SignUpDetails newSignUpDetails)
        {
            bool isReasonValid = new[] { "advert", "wordOfMouth", "other" }.Contains(newSignUpDetails.SourceOfInformation);
            if (!isReasonValid)
            {
                return new ValidationResult()
                {
                    IsValid = false,
                    ErrorMessage = "The SourceOfInformation field is not valid"
                };
            }
            var signUpDetails = await _dbContext.SignUpDetails.FirstOrDefaultAsync(s => s.Email == newSignUpDetails.Email);
            if (signUpDetails != null)
            {
                return new ValidationResult()
                {
                    IsValid = false,
                    ErrorMessage = "This email address is already signed up!"
                };
            }
            return new ValidationResult()
            {
                IsValid = true
            };
        }
        public async Task SaveSignUpDetails(SignUpDetails newSignUpDetails)
        {
            _dbContext.SignUpDetails.Add(newSignUpDetails);
            await _dbContext.SaveChangesAsync();
        }
    }
}
