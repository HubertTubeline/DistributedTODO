using FluentValidation;
using FluentValidation.Attributes;

namespace DistributedToDo.Web.Models
{
    [Validator(typeof(RegisterModelValidator))]
    public class RegisterModel
    {
        public string Email { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Number { get; set; }

        public string Comment { get; set; }

        public string Photo { get; set; }
    }

    public class RegisterModelValidator : AbstractValidator<RegisterModel>
    {
        public RegisterModelValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(x => Resources.Resource.ErrorRequired)
                .EmailAddress().WithMessage(x => Resources.Resource.EmailError);
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(x => Resources.Resource.ErrorRequired)
                .Length(6, 32).WithMessage(x => Resources.Resource.PasswordLength);
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage(x => Resources.Resource.ErrorRequired)
                .Equal(x => x.Password).WithMessage(x => Resources.Resource.PasswordsDoNotMatch);
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage(x => Resources.Resource.ErrorRequired);
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage(x => Resources.Resource.ErrorRequired);
            RuleFor(x => x.Number)
                .NotEmpty().WithMessage(x => Resources.Resource.ErrorRequired);
            RuleFor(x => x.Comment)
                .MaximumLength(256).WithMessage(x => Resources.Resource.CommentIsLong);
        }
    }
}