using Application.Features.SharedFiles.Commands.Create;
using Application.Features.SharedFiles.Commands.Delete;
using Application.Features.SharedFiles.Commands.Update;
using Application.Features.SharedFiles.Queries.GetById;
using Application.Features.SharedFiles.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FileUploadSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharedFilesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SharedFilesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSharedFileCommand command)
        {
            var result = await _mediator.Send(command);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSharedFileCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteSharedFileCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdSharedFileQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var query = new GetListSharedFileQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
