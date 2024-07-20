using Core.DataAccess;
using System;

namespace FileUploadSystem.Domain.Entities
{
    public class SharedFile : Entity<int>
    {
        public int FileId { get; private set; }
        public int UserId { get; private set; }
        public UploadedFile File { get; private set; }
        public User User { get; private set; }

        public SharedFile() : base()
        {
        }

        public SharedFile(int id, int fileId, int userId) : base(id)
        {
            FileId = fileId;
            UserId = userId;
        }
    }
}
