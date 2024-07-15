using Application.Repositories;
using Core.DataAccess;
using Core.Entities;
using FileUploadSystem.Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, FileUploadDbContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(FileUploadDbContext context) : base(context)
        {
        }
    }
}
