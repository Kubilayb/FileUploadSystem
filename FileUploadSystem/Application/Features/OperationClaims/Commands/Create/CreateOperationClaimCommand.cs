using Application.Repositories;
using AutoMapper;
using Core.Hashing;
using FileUploadSystem.Domain.Entities;
using MediatR;

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

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CreateUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            user.Password = HashingHelper.HashPassword(request.Password); // Password hashing logic
            var createdUser = await _userRepository.AddAsync(user);
            var userDto = _mapper.Map<CreateUserDto>(createdUser);
            return userDto;
        }
    }
}
