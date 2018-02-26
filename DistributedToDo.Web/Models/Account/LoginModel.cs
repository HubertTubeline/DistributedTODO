using FluentValidation;
using FluentValidation.Attributes;

namespace DistributedToDo.Web.Models
{
    [Validator(typeof(LoginModelValidator))]
    public class LoginModel
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
    public class LoginModelValidator : AbstractValidator<LoginModel>
    {
        public LoginModelValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(x => Resources.Resource.EmailEmpty)
                .EmailAddress().WithMessage(x => Resources.Resource.EmailError);
            RuleFor(x => x.Password)
                .Length(6,32).WithMessage(x => Resources.Resource.PasswordLength)
                .NotEmpty().WithMessage(x => Resources.Resource.PasswordIsEmpty);
        }
    }
}