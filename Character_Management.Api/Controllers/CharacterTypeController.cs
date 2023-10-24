using Character_Management.Application.DTOs.CharacterType;
using Character_Management.Application.Features.CharacterTypes.Requests.Commands;
using Character_Management.Application.Features.CharacterTypes.Requests.Queries;
using Character_Management.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?Linkid=397860

namespace Character_Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CharacterTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<CharacterTypeController>
        [HttpGet]
        public async Task<ActionResult<List<CharacterTypeDto>>> Get()
        {
            var command = new GetCharacterTypeListRequest();
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // GET api/<CharacterTypeController>/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<CharacterTypeDto>> Get(int Id)
        {
            var command = new GetCharacterTypeDetailRequest { Id = Id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // POST api/<CharacterTypeController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCharacterTypeDto createCharacterTypeDto)
        {
            var command = new CreateCharacterTypeCommand { CreateCharacterTypeDto = createCharacterTypeDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<CharacterTypeController>/5
        [HttpPut("{Id}")]
        public async Task<ActionResult> Put(int Id, [FromBody] UpdateCharacterTypeDto updateCharacterTypeCommand)
        {
            var command = new UpdateCharacterTypeCommand { Id = Id, UpdateCharacterTypeDto = updateCharacterTypeCommand };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<CharacterTypeController>/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var command = new DeleteCharacterTypeCommand { Id = Id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
