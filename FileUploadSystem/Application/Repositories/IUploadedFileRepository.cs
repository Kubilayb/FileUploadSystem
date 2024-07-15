using Core.DataAccess;
using FileUploadSystem.Domain.Entities;

namespace Application.Repositories
{
    public interface IUploadedFileRepository : IAsyncRepository<UploadedFile>, IRepository<UploadedFile>
    {
    }
}
