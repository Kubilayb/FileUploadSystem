using Core.DataAccess;
using FileUploadSystem.Domain.Entities;

namespace Application.Repositories
{
    public interface ISharedFileRepository : IAsyncRepository<SharedFile>, IRepository<SharedFile>
    {
    }
}
