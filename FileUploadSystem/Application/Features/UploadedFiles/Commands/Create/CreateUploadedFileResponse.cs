namespace Application.Features.UploadedFiles.Commands.Create
{
    public class CreateUploadedFileResponse
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
    }
}
