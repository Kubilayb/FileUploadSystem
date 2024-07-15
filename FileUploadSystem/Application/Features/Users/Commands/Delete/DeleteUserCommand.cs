using MediatR;
using Application.Repositories;
using Application.Features.Users.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Application.Features.Users.Commands.Delete
{
    public class DeleteUserCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserBusinessRules _userBusinessRules;

        public DeleteUserCommandHandler(IUserRepository userRepository, UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null) throw new NotFoundException("User not found");

            await _userRepository.DeleteAsync(user);
            return Unit.Value;
        }
    }
}
