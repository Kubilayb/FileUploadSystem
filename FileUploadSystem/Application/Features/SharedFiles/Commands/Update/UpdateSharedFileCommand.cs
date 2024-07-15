namespace Application.Features.SharedFiles.Commands.Update
{
    public class UpdateSharedFileCommand
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
    }
}
