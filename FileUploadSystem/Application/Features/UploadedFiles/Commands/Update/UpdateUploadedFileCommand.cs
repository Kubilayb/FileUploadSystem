namespace Application.Features.UploadedFiles.Commands.Update
{
    public class UpdateUploadedFileCommand
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
    }
}
