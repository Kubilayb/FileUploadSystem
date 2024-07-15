using FluentValidation;

namespace Application.Features.SharedFiles.Commands.Create
{
    public class CreateSharedFileCommandValidator : AbstractValidator<CreateSharedFileCommand>
    {
        public CreateSharedFileCommandValidator()
        {
            RuleFor(c => c.FileName).NotEmpty().WithMessage("File name is required.");
            RuleFor(c => c.Content).NotEmpty().WithMessage("File content is required.");
            RuleFor(c => c.ContentType).NotEmpty().WithMessage("Content type is required.");
        }
    }
}
