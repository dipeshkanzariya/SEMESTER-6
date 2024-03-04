using API_Demo.Models;
using FluentValidation;

namespace API_Demo.UserValidator
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(UserModel => UserModel.UserName).NotEmpty();
            RuleFor(UserModel => UserModel.Contact).NotEmpty();
            RuleFor(UserModel => UserModel.Email).NotEmpty();
        }
    }
}
