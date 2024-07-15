using MediatR;
using Application.Repositories;
using FileUploadSystem.Domain.Entities;

namespace Application.Features.UserOperationClaims.Commands.Create
{
    public class CreateUserOperationClaimCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }

    public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, int>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<int> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            var userOperationClaim = new UserOperationClaim
            {
                UserId = request.UserId,
                OperationClaimId = request.OperationClaimId
            };

            var createdUserOperationClaim = await _userOperationClaimRepository.AddAsync(userOperationClaim);
            return createdUserOperationClaim.Id;
        }
    }
}
