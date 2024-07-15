using Application.Features.UploadedFiles.Queries.GetList;
using AutoMapper;
using FileUploadSystem.Domain.Entities;

namespace Application.Features.SharedFiles.Profiles
{
    public class SharedFileMappingProfile : Profile
    {
        public SharedFileMappingProfile()
        {
            CreateMap<CreateSharedFileCommand, SharedFile>();
            CreateMap<UpdateSharedFileCommand, SharedFile>();
            CreateMap<SharedFile, CreateSharedFileResponse>();
            CreateMap<SharedFile, UpdateSharedFileResponse>();
            CreateMap<SharedFile, GetByIdSharedFileResponse>();
            CreateMap<SharedFile, GetListSharedFileResponse>();
        }
    }
}
