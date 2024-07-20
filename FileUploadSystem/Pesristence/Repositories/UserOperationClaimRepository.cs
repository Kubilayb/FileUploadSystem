using Application.Repositories;
using Core.DataAccess;
using Core.Entities;
using FileUploadSystem.Domain.Entities;
using FileUploadSystem.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, FileUploadDbContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(FileUploadDbContext context) : base(context)
        {
        }

        public async Task<UserOperationClaim> GetByIdAsync(int id)
        {
            return await Query().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
