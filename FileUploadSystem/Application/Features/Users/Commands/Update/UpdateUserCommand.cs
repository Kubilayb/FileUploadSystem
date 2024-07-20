using MediatR;
using AutoMapper;
using Application.Dtos;
using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Hashing;
using Application.Features.Users.Rules;
using FileUploadSystem.Domain.Entities;

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
            var userControll = await _userRepository.GetAsync(i => i.Id == request.Id);
            if (userControll == null) throw new NotFoundException("User not found");

            await _userBusinessRules.EmailCannotBeDuplicatedWhenUpdated(request.Email, request.Id);

            User user = _mapper.Map<User>(request);

            byte[] passwordHash, passwordSalt;

            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;

            await _userRepository.UpdateAsync(user);

            UpdateUserDto updateUserDto = _mapper.Map<UpdateUserDto>(user);

            return updateUserDto;
        }
    }
    
}
