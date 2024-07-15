using Core.DataAccess;
using Core.Entities;
using FileUploadSystem.Domain.Entities;

namespace Application.Repositories
{
    public interface IUploadedFileRepository : IAsyncRepository<UploadedFile>, IRepository<UploadedFile>
    {
    }
}
