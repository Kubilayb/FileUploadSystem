using Application.Repositories;
using Core.DataAccess;
using Core.Entities;
using FileUploadSystem.Domain.Entities;
using FileUploadSystem.Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UploadedFileRepository : EfRepositoryBase<UploadedFile, FileUploadDbContext>, IUploadedFileRepository
    {
        public UploadedFileRepository(FileUploadDbContext context) : base(context)
        {
        }
    }
}
