namespace FileUploadSystem.Application.DTOs
{
    public class UploadedFileDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
