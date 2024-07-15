namespace Application.Features.SharedFiles.Commands.Create
{
    public class CreateSharedFileResponse
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
    }
}
