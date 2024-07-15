using Application.Features.UploadedFiles.Commands.Create;
using Application.Features.UploadedFiles.Commands.Delete;
using Application.Features.UploadedFiles.Commands.Update;
using Application.Features.UploadedFiles.Queries.GetById;
using Application.Features.UploadedFiles.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FileUploadSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadedFilesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UploadedFilesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUploadedFileCommand command)
        {
            var result = await _mediator.Send(command);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUploadedFileCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteUploadedFileCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdUploadedFileQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var query = new GetListUploadedFileQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
