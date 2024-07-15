using Application.Repositories;
using FileUploadSystem.Application.DTOs;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.UploadedFileService
{
    public class UploadedFileManager : IUploadedFileService
    {
        private readonly IUploadedFileRepository _uploadedFileRepository; // Eğer varsa repository bağlantısı

        public UploadedFileManager(IUploadedFileRepository uploadedFileRepository)
        {
            _uploadedFileRepository = uploadedFileRepository;
        }

        public async Task<UploadedFileDto> UploadFileAsync(UploadedFileDto fileDto)
        {
            // Implementasyon gereksinimlerine göre dosya yükleme işlemi
            throw new NotImplementedException();
        }

        public async Task<UploadedFileDto> UploadFileAsync(IFormFile file)
        {
            // Implementasyon gereksinimlerine göre dosya yükleme işlemi
            throw new NotImplementedException();
        }

        public async Task UpdateFileAsync(int id, IFormFile file)
        {
            // Implementasyon gereksinimlerine göre dosya güncelleme işlemi
            throw new NotImplementedException();
        }

        public async Task DeleteFileAsync(int id)
        {
            // Implementasyon gereksinimlerine göre dosya silme işlemi
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UploadedFileDto>> GetFilesAsync()
        {
            // Implementasyon gereksinimlerine göre tüm dosyaları getirme işlemi
            throw new NotImplementedException();
        }

        public async Task<UploadedFileDto> GetFileByIdAsync(int id)
        {
            // Implementasyon gereksinimlerine göre id'ye göre dosya getirme işlemi
            throw new NotImplementedException();
        }
    }
}
