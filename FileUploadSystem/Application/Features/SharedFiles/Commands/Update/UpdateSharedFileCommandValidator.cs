using FluentValidation;

namespace Application.Features.SharedFiles.Commands.Update
{
    public class UpdateSharedFileCommandValidator : AbstractValidator<UpdateSharedFileCommand>
    {
        public UpdateSharedFileCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("File ID is required.");
            RuleFor(c => c.FileName).NotEmpty().WithMessage("File name is required.");
            RuleFor(c => c.Content).NotEmpty().WithMessage("File content is required.");
            RuleFor(c => c.ContentType).NotEmpty().WithMessage("Content type is required.");
        }
    }
}
