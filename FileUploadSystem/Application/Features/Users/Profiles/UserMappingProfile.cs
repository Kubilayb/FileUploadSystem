using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Queries.GetById;
using Application.Features.Users.Queries.GetList;
using AutoMapper;
using Core.Paging;
using Core.Responses;
using Domain.Entities;
using Domain.Enums;

namespace Application.Features.Users.Profiles
{
    public class SharedFileMappingProfile : Profile
    {
        public SharedFileMappingProfile()
        {
            CreateMap<User, CreateUploadedFileCommand>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.ToString()))
                .ReverseMap()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => Enum.Parse<Gender>(src.Gender, true)))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => Enum.Parse<City>(src.City, true)));
            CreateMap<User, CreateUploadedFileResponse>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.ToString()))
                .ReverseMap();
            CreateMap<User, UpdateSharedFileCommand>()
               .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
               .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.ToString()))
               .ReverseMap()
               .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => Enum.Parse<Gender>(src.Gender, true)))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => Enum.Parse<City>(src.City, true)));
            CreateMap<User, UpdateSharedFileResponse>()
               .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
               .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.ToString()))
               .ReverseMap();
            CreateMap<User, GetListUserQuery>().ReverseMap();
            CreateMap<User, GetListUserResponse>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.ToString()))
                .ReverseMap();
            CreateMap<IPaginate<User>, GetListResponse<GetListUserResponse>>().ReverseMap();
            CreateMap<User, GetByIdSharedFileQuery>().ReverseMap();
            CreateMap<User, GetByIdSharedFileResponse>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.ToString()))
                .ReverseMap();

            CreateMap<Patient, CreateUploadedFileCommand>().ReverseMap();
        }
    }
}
