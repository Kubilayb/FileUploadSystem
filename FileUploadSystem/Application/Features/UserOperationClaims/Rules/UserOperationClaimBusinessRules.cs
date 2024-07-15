using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
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

        public async Task OperationClaimCannotBeDuplicatedWhenInserted(int userId, int operationClaimId)
        {
            var existingUserOperationClaim = await _userOperationClaimRepository.GetAsync(uoc => uoc.UserId == userId && uoc.OperationClaimId == operationClaimId);
            if (existingUserOperationClaim != null)
            {
                throw new BusinessException("Operation claim already exists for this user.");
            }
        }
    }
    public async Task OperationClaimCannotBeDuplicatedWhenUpdated(int id, int userId, int operationClaimId)
    {
        var existingUserOperationClaim = await _userOperationClaimRepository.GetAsync(uoc => uoc.UserId == userId && uoc.OperationClaimId == operationClaimId && uoc.Id != id);
        if (existingUserOperationClaim != null)
        {
            throw new BusinessException("Operation claim already exists for this user.");
        }
    }

}
