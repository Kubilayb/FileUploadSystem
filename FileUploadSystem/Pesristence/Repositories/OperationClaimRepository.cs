using Application.Repositories;
using Core.DataAccess;
using Core.Entities;
using FileUploadSystem.Persistence.Contexts;

namespace Persistence.Repositories
{
    public class OperationClaimRepository : EfRepositoryBase<OperationClaim, FileUploadDbContext>,
        IOperationClaimRepository
    {
        public OperationClaimRepository(FileUploadDbContext context) : base(context)
        {
        }
    }
}
