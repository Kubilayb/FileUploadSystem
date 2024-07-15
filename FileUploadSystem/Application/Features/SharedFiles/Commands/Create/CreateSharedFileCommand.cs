namespace Application.Features.SharedFiles.Commands.Create
{
    public class CreateSharedFileCommand
    {
        // Properties
        public string FileName { get; set; }
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
    }
}
