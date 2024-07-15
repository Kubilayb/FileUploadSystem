using Application.Repositories;
using Core.DataAccess;
using Core.Entities;
using FileUploadSystem.Persistence.Contexts;

public class SharedFileRepository : EfRepositoryBase<UserOperationClaim, FileUploadDbContext>, IUserOperationClaimRepository
{
    public SharedFileRepository(FileUploadDbContext context) : base(context)
    {
    }
}