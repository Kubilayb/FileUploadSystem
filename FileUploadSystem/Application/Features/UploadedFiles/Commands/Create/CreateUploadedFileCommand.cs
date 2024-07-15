namespace Application.Features.UploadedFiles.Commands.Create
{
    public class CreateUploadedFileCommand
    {
        // Properties
        public string FileName { get; set; }
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
    }
}
