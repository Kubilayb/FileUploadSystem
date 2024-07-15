using Application.Features.Auth.Commands.Register;
using AutoMapper;
using FileUploadSystem.Domain.Entities;

namespace Application.Features.Auth.Profiles
{
    public class AuthMappingProfile : Profile
    {
        public AuthMappingProfile()
        {
            CreateMap<User, RegisterCommand>().ReverseMap();
        }
    }
}
