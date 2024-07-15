using MediatR;
using AutoMapper;
using Application.Dtos;
using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Hashing;
using Application.Features.Users.Rules;

namespace Application.Features.Users.Commands.Update
{
    public class UpdateUserCommand : IRequest<UpdateUserDto>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<UpdateUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null) throw new NotFoundException("User not found");

            await _userBusinessRules.EmailCannotBeDuplicatedWhenUpdated(request.Email, request.Id);

            _mapper.Map(request, user);
            user.Password = HashingHelper.HashPassword(request.Password); // Password hashing logic
            await _userRepository.UpdateAsync(user);
            var userDto = _mapper.Map<UpdateUserDto>(user);
            return userDto;
        }
    }
}
