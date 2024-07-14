using FileUploadSystem.Application.Interfaces;
using FileUploadSystem.Domain.Entities;
using FileUploadSystem.Persistence.Context;

namespace FileUploadSystem.Persistence.Repositories
{
    public class FileRepository : Repository<File>, IFileRepository
    {
        public FileRepository(FileUploadDbContext context) : base(context)
        {
        }
    }
}
