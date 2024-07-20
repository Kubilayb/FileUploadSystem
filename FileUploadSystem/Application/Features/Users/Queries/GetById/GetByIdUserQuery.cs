using MediatR;
using AutoMapper;
using Application.Dtos;
using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Application.Features.Users.Queries.GetById
{
    public class GetByIdUserQuery : IRequest<UserDto>
    {
        public int Id { get; set; }
    }

    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetByIdUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(i => i.Id == request.Id);
            if (user == null) throw new NotFoundException("User not found");

            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}
