using MediatR;
using AutoMapper;
using Application.Dtos;
using Application.Repositories;
using Core.Domain.Entities;
using Application.Features.UserOperationClaims.Rules;
using Core.Entities;

namespace Application.Features.UserOperationClaims.Commands.Create
{
    public class CreateUserOperationClaimCommand : IRequest<CreateUserOperationClaimDto>
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }

    public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, CreateUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

        public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        }

        public async Task<CreateUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            await _userOperationClaimBusinessRules.OperationClaimCannotBeDuplicatedWhenInserted(request.UserId, request.OperationClaimId);

            var userOperationClaim = _mapper.Map<UserOperationClaim>(request);
            var createdUserOperationClaim = await _userOperationClaimRepository.AddAsync(userOperationClaim);
            var userOperationClaimDto = _mapper.Map<CreateUserOperationClaimDto>(createdUserOperationClaim);
            return userOperationClaimDto;
        }
    }
}
