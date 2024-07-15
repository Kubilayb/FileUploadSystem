using Application.Repositories;
using Core.DataAccess;
using FileUploadSystem.Domain.Entities;
using FileUploadSystem.Persistence.Contexts;

namespace Persistence.Repositories
{
    public class SharedFileRepository : EfRepositoryBase<SharedFile, FileUploadDbContext>, ISharedFileRepository
    {
        public SharedFileRepository(FileUploadDbContext context) : base(context)
        {
        }
    }
}
