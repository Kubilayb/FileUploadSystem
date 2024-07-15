using FluentValidation;

namespace Application.Features.UploadedFiles.Commands.Create
{
    public class CreateUploadedFileCommandValidator : AbstractValidator<CreateUploadedFileCommand>
    {
        public CreateUploadedFileCommandValidator()
        {
            RuleFor(c => c.FileName).NotEmpty().WithMessage("File name is required.");
            RuleFor(c => c.Content).NotEmpty().WithMessage("File content is required.");
            RuleFor(c => c.ContentType).NotEmpty().WithMessage("Content type is required.");
        }
    }
}
