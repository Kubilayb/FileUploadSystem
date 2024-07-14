using Core.DataAccess;
using FileUploadSystem.Domain.Entities;

namespace FileUploadSystem.Application.Interfaces
{
    public interface IFileRepository : IRepository<File>
    {
    }
}
