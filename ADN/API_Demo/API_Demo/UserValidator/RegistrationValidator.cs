using API_Demo.Models;
using FluentValidation;

namespace API_Demo.UserValidator
{
    public class RegistrationValidator : AbstractValidator<RegisterationModel>
    {
        public RegistrationValidator()
        {
            RuleFor(RegisterationModel => RegisterationModel.UserName)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(30)
                .WithMessage("User name must be in between 5 to 30 character");

            RuleFor(RegisterationModel => RegisterationModel.Password)
                .NotEmpty()
                .Matches()
        }
    }
}
