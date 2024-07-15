using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public UserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task OperationClaimCannotBeDuplicatedWhenUpdated(int userId, int operationClaimId)
        {
            var userOperationClaim = await _userOperationClaimRepository.GetAsync(u => u.UserId == userId && u.OperationClaimId == operationClaimId);
            if (userOperationClaim != null) throw new BusinessException("This operation claim is already assigned to the user.");
        }
    }
}
