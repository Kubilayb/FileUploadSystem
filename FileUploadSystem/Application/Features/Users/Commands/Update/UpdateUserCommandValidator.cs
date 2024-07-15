using FluentValidation;

namespace Application.Features.Users.Commands.Update
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Enter a valid email address.");
            RuleFor(i => i.FirstName).NotEmpty().WithMessage("FirstName cannot be empty.");
            RuleFor(i => i.LastName).NotEmpty().WithMessage("LastName cannot be empty.");
            RuleFor(i => i.Password).NotEmpty().WithMessage("Password cannot be empty.");
        }
    }
}
