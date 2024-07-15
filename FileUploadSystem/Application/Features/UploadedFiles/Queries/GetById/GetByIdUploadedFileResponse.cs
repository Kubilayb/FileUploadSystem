namespace Application.Features.UploadedFiles.Queries.GetById
{
    public class GetByIdUploadedFileResponse
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
    }
}
