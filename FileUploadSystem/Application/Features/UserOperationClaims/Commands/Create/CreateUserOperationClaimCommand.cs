using MediatR;
using Application.Repositories;
using FileUploadSystem.Domain.Entities;
using Core.Entities;
using AutoMapper;

namespace Application.Features.UserOperationClaims.Commands.Create
{
    public class CreateUserOperationClaimCommand : IRequest<CreateUserOperationClaimResponse>
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }



    public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, CreateUserOperationClaimResponse>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        private readonly IMapper _mapper;
        public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<CreateUserOperationClaimResponse> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            UserOperationClaim userOperationClaim = _mapper.Map<UserOperationClaim>(request);

            await _userOperationClaimRepository.AddAsync(userOperationClaim);

            CreateUserOperationClaimResponse createUserOperationClaimResponse = _mapper.Map<CreateUserOperationClaimResponse>(userOperationClaim);

            return createUserOperationClaimResponse;

        }
    }
}


// Ali Başdemir tarafından yapıldı