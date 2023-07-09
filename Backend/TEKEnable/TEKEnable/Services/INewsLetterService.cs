using TEKEnable.Models;

namespace TEKEnable.Services
{
    public interface INewsLetterService
    {
        Task<ValidationResult> ValidateSignUpDetails(SignUpDetails newSignUpDetails);
        Task SaveSignUpDetails(SignUpDetails newSignUpDetails);
    }
}
