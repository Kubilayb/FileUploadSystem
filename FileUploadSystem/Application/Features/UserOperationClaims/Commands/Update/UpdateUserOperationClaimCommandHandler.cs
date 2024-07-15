//using MediatR;
//using Application.Repositories;
//using AutoMapper;
//using Core.CrossCuttingConcerns.Exceptions.Types;
//using System.Threading;
//using System.Threading.Tasks;
//using Application.Features.UserOperationClaims.Rules;

//namespace Application.Features.UserOperationClaims.Commands.Update
//{
//    public class UpdateUserOperationClaimCommand : IRequest<int>
//    {
//        public int Id { get; set; }
//        public int UserId { get; set; }
//        public int OperationClaimId { get; set; }
//    }

//    public class UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand, int>
//    {
//        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
//        private readonly IMapper _mapper;
//        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

//        public UpdateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
//        {
//            _userOperationClaimRepository = userOperationClaimRepository;
//            _mapper = mapper;
//            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
//        }

//        public async Task<int> Handle(UpdateUserOperationClaimCommand request, CancellationToken cancellationToken)
//        {
//            var userOperationClaim = await _userOperationClaimRepository.GetByIdAsync(request.Id);
//            if (userOperationClaim == null) throw new NotFoundException("User Operation Claim not found");

//            await _userOperationClaimBusinessRules.OperationClaimCannotBeDuplicatedWhenUpdated(request.UserId, request.OperationClaimId);

//            _mapper.Map(request, userOperationClaim);
//            await _userOperationClaimRepository.UpdateAsync(userOperationClaim);
//            return userOperationClaim.Id;
//        }
//    }
//}
