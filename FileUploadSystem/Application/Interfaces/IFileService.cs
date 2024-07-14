using FileUploadSystem.Application.DTOs;
using FileUploadSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileUploadSystem.Application.Interfaces
{
    public interface IFileService
    {
        Task<IEnumerable<FileDto>> GetFilesAsync();
        Task<FileDto> GetFileByIdAsync(Guid id);
        Task UploadFileAsync(FileDto file);
        Task UpdateFileAsync(FileDto file);
        Task DeleteFileAsync(Guid id);
    }
}
