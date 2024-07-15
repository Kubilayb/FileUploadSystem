using Application.Repositories;
using Core.DataAccess;
using Core.Entities;
using FileUploadSystem.Persistence.Contexts;

public class UploadedFileRepository : EfRepositoryBase<UploadedFileRepository, FileUploadDbContext>, IUploadedFileOperationClaimRepository
{
    public UploadedFileRepository(FileUploadDbContext context) : base(context)
    {
    }
}