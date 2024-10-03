using FluentValidation;
using Shop.User.API.Models;

namespace Shop.User.API.Validations
{
    public class UserUpdateValidator : AbstractValidator<UserModel>
    {
        public UserUpdateValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Please enter a username")
                .MinimumLength(2).WithMessage("The length of the username must be more than 1 character");

            //RuleFor(x => x.Telephone)
            //    .Matches();
        }
    }
}
