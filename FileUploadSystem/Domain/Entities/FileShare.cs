using Core.DataAccess;
using System;

namespace FileUploadSystem.Domain.Entities
{
    public class FileShare : Entity<Guid>
    {
        public Guid FileId { get; private set; }
        public Guid UserId { get; private set; }
        public File File { get; private set; }
        public User User { get; private set; }

        public FileShare() : base()
        {
        }

        public FileShare(Guid id, Guid fileId, Guid userId) : base(id)
        {
            FileId = fileId;
            UserId = userId;
        }
    }
}
