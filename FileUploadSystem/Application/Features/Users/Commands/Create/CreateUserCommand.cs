using MediatR;
using AutoMapper;
using Application.Dtos;
using Application.Repositories;
using Core.Hashing;
using FileUploadSystem.Domain.Entities;
using Application.Features.Users.Rules;
using Microsoft.AspNetCore.Identity;

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


            User user = _mapper.Map<User>(request);

            byte[] passwordHash, passwordSalt; 

            HashingHelper.CreatePasswordHash(request.Password,out passwordHash,out passwordSalt);

            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;

            await _userRepository.AddAsync(user);
            var userDto = _mapper.Map<CreateUserDto>(user);
            return userDto;
        }
    }
}
