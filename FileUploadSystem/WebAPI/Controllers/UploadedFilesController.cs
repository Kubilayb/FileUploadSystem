using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]")]
[ApiController]
public class UploadedFilesController : ControllerBase
{
    private readonly IUploadedFileService _fileService;

    public UploadedFilesController(IUploadedFileService fileService)
    {
        _fileService = fileService;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        var result = await _fileService.UploadFileAsync(file);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFile(int id, IFormFile file)
    {
        var result = await _fileService.UpdateFileAsync(id, file);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFile(int id)
    {
        await _fileService.DeleteFileAsync(id);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetFiles()
    {
        var result = await _fileService.GetFilesAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFileById(int id)
    {
        var result = await _fileService.GetFileByIdAsync(id);
        return Ok(result);
    }
}