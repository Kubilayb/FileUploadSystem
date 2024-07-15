using AutoMapper;
using MediatR;
using Application.Dtos;
using Application.Repositories;
using Core.Domain.Entities;
using Application.Features.UserOperationClaims.Rules;

namespace Application.Features.UserOperationClaims.Commands.Update
{
    public class UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand, UpdateUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

        public UpdateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        }

        public async Task<UpdateUserOperationClaimDto> Handle(UpdateUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            await _userOperationClaimBusinessRules.OperationClaimCannotBeDuplicatedWhenUpdated(request.Id, request.UserId, request.OperationClaimId);

            var userOperationClaim = await _userOperationClaimRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, userOperationClaim);

            var updatedUserOperationClaim = await _userOperationClaimRepository.UpdateAsync(userOperationClaim);
            var userOperationClaimDto = _mapper.Map<UpdateUserOperationClaimDto>(updatedUserOperationClaim);
            return userOperationClaimDto;
        }
    }
}
