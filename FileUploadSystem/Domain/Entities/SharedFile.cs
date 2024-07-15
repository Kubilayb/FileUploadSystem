using Core.DataAccess;
using System;

namespace FileUploadSystem.Domain.Entities
{
    public class SharedFile : Entity<Guid>
    {
        public Guid FileId { get; private set; }
        public Guid UserId { get; private set; }
        public UploadedFile File { get; private set; }
        public User User { get; private set; }

        public SharedFile() : base()
        {
        }

        public SharedFile(Guid id, Guid fileId, Guid userId) : base(id)
        {
            FileId = fileId;
            UserId = userId;
        }
    }
}
