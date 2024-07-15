using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.Hashing;
using Domain.Entities;
using MediatR;
using static Application.Features.Users.Constants.UsersOperationClaims;

namespace Application.Features.Users.Commands.Create
{
    public class CreateUploadedFileCommand : IRequest<CreateUploadedFileResponse>, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, Write, Add };

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PhotoUrl { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUploadedFileCommand, CreateUploadedFileResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly IPatientRepository _petientRepository; // todo refactor

            public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IPatientRepository petientRepository)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _petientRepository = petientRepository;
            }

            public async Task<CreateUploadedFileResponse> Handle(CreateUploadedFileCommand request, CancellationToken cancellationToken)
            {
                User user = _mapper.Map<User>(request);
                Patient patient = _mapper.Map<Patient>(request);

                byte[] passwordHash, passwordSalt;

                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;
                user.UserType = "patient"; // todo refactor

                await _userRepository.AddAsync(user);

                patient.UserId = user.Id;
                await _petientRepository.AddAsync(patient);

                CreateUploadedFileResponse response = _mapper.Map<CreateUploadedFileResponse>(user);
                return response;
            }
        }
    }
}

