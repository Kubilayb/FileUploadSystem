using MediatR;
using AutoMapper;
using Application.Dtos;
using Application.Repositories;
using Core.Domain.Entities;
using Application.Features.Users.Rules;
using Core.Hashing;
using FileUploadSystem.Domain.Entities;

namespace Application.Features.Users.Commands.Create
{
    public class CreateUserCommand : IRequest<CreateUserDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<CreateUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.EmailCannotBeDuplicatedWhenInserted(request.Email);

            var user = _mapper.Map<User>(request);
            user.Password = HashingHelper.HashPassword(request.Password); // Password hashing logic
            var createdUser = await _userRepository.AddAsync(user);
            var userDto = _mapper.Map<CreateUserDto>(createdUser);
            return userDto;
        }
    }
}
