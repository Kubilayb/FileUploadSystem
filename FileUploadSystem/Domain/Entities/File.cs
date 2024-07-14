using Core.DataAccess;
using System;

namespace FileUploadSystem.Domain.Entities
{
    public class File : Entity<Guid>
    {
        public string FileName { get; private set; }
        public string FilePath { get; private set; }
        public DateTime UploadDate { get; private set; }

        public File() : base()
        {
        }

        public File(Guid id, string fileName, string filePath, DateTime uploadDate) : base(id)
        {
            FileName = fileName;
            FilePath = filePath;
            UploadDate = uploadDate;
        }
    }
}
