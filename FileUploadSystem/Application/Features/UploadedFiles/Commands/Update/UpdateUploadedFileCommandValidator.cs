using FluentValidation;

namespace Application.Features.UploadedFiles.Commands.Update
{
    public class UpdateUploadedFileCommandValidator : AbstractValidator<UpdateUploadedFileCommand>
    {
        public UpdateUploadedFileCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("File ID is required.");
            RuleFor(c => c.FileName).NotEmpty().WithMessage("File name is required.");
            RuleFor(c => c.Content).NotEmpty().WithMessage("File content is required.");
            RuleFor(c => c.ContentType).NotEmpty().WithMessage("Content type is required.");
        }
    }
}
