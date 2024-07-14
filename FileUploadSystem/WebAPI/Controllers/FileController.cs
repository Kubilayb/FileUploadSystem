using Microsoft.AspNetCore.Mvc;
using FileUploadSystem.Application.Interfaces;
using FileUploadSystem.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace FileUploadSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFiles()
        {
            var files = await _fileService.GetFilesAsync();
            return Ok(files);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFileById(Guid id)
        {
            var file = await _fileService.GetFileByIdAsync(id);
            if (file == null)
            {
                return NotFound();
            }
            return Ok(file);
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile([FromBody] File file)
        {
            await _fileService.UploadFileAsync(file);
            return CreatedAtAction(nameof(GetFileById), new { id = file.Id }, file);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFile(Guid id, [FromBody] File file)
        {
            if (id != file.Id)
            {
                return BadRequest();
            }
            await _fileService.UpdateFileAsync(file);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFile(Guid id)


