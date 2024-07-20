using Core.DataAccess;
using System;

namespace FileUploadSystem.Domain.Entities
{
    public class UploadedFile : Entity<int>
    {
        public string FileName { get; private set; }
        public string FilePath { get; private set; }
        public DateTime UploadDate { get; private set; }

        public UploadedFile() : base()
        {
        }

        public UploadedFile(int id, string fileName, string filePath, DateTime uploadDate) : base(id)
        {
            FileName = fileName;
            FilePath = filePath;
            UploadDate = uploadDate;
        }
    }
}
