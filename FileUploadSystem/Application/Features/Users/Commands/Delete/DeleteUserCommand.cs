using MediatR;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Application.Repositories;
using System.Threading;
using System.Threading.Tasks;
using FileUploadSystem.Domain.Entities;

namespace Application.Features.Users.Commands.Delete
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetAsync(i=>i.Id==request.Id);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            await _userRepository.DeleteAsync(user);

            return Unit.Value;
        }
    }
}
