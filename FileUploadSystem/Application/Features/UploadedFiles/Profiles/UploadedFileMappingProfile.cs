using Application.Features.UploadedFiles.Commands.Update;
using AutoMapper;
using FileUploadSystem.Domain.Entities;

namespace Application.Features.UploadedFiles.Profiles
{
    public class UploadedFileMappingProfile : Profile
    {
        public UploadedFileMappingProfile()
        {
            CreateMap<CreateUploadedFileCommand, UploadedFile>();
            CreateMap<UpdateUploadedFileCommand, UploadedFile>();
            CreateMap<UploadedFile, CreateUploadedFileResponse>();
            CreateMap<UploadedFile, UpdateUploadedFileResponse>();
            CreateMap<UploadedFile, GetByIdUploadedFileResponse>();
            CreateMap<UploadedFile, GetListUploadedFileResponse>();
        }
    }
}
