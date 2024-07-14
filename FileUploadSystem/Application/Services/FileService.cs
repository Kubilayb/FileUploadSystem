using FileUploadSystem.Application.Interfaces;
using FileUploadSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileUploadSystem.Application.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;

        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<IEnumerable<File>> GetFilesAsync()
        {
            return await _fileRepository.GetAllAsync();
        }

        public async Task<File> GetFileByIdAsync(Guid id)
        {
            return await _fileRepository.GetByIdAsync(id);
        }

        public async Task UploadFileAsync(File file)
        {
            await _fileRepository.AddAsync(file);
        }

        public async Task UpdateFileAsync(File file)
        {
            await _fileRepository.UpdateAsync(file);
        }

        public async Task DeleteFileAsync(Guid id)
        {
            await _fileRepository.DeleteAsync(id);
        }
    }
}
