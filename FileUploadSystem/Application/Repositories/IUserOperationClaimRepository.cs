using Core.DataAccess;
using Core.Entities;

namespace Application.Repositories
{
    public interface IUserOperationClaimRepository : IAsyncRepository<UserOperationClaim>, IRepository<UserOperationClaim>
    {
        Task<UserOperationClaim> GetByIdAsync(int id);
    }
}
