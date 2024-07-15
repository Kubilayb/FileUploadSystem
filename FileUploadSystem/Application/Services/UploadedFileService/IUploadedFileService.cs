using System.Collections.Generic;
using System.Threading.Tasks;
using FileUploadSystem.Application.DTOs;
using Microsoft.AspNetCore.Http;

namespace Application.Services.UploadedFileService
{
    public interface IUploadedFileService
    {
        Task<UploadedFileDto> UploadFileAsync(UploadedFileDto fileDto);
        Task<UploadedFileDto> UploadFileAsync(IFormFile file);
        Task UpdateFileAsync(int id, IFormFile file);
        Task DeleteFileAsync(int id);
        Task<IEnumerable<UploadedFileDto>> GetFilesAsync();
        Task<UploadedFileDto> GetFileByIdAsync(int id);
    }
}
