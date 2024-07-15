using System.Collections.Generic;
using System.Threading.Tasks;
using FileUploadSystem.Application.DTOs;

namespace Application.Services.SharedFileService
{
    public interface ISharedFileService
    {
        Task<SharedFileDto> ShareFileAsync(SharedFileDto sharedFileDto);
        Task<IEnumerable<SharedFileDto>> GetSharedFilesAsync();
        // Diğer metotlar burada yer alabilir
    }
}
