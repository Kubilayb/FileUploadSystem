using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class SharedFilesController : ControllerBase
{
    private readonly ISharedFileRepository _fileShareService;

    public SharedFilesController(ISharedFileRepository fileShareService)
    {
        _fileShareService = fileShareService;
    }

    [HttpPost("share")]
    public async Task<IActionResult> ShareFile(int fileId, int userId)
    {
        var result = await _fileShareService.ShareFileAsync(fileId, userId);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetFileShares()
    {
        var result = await _fileShareService.GetFileSharesAsync();
        return Ok(result);
    }
}