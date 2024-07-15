using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class SharedFilesController : ControllerBase
{
    private readonly ISharedFileService _sharedFileService;

    public SharedFilesController(ISharedFileService sharedFileService)
    {
        _sharedFileService = sharedFileService;
    }

    [HttpPost("share")]
    public async Task<IActionResult> ShareFile(int fileId, int userId)
    {
        var result = await _sharedFileService.ShareFileAsync(fileId, userId);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetSharedFiles()
    {
        var result = await _sharedFileService.GetSharedFilesAsync();
        return Ok(result);
    }
}