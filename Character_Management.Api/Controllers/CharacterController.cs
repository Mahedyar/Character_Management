using Character_Management.Application.DTOs.Character;
using Character_Management.Application.Features.Characters.Requests.Commands;
using Character_Management.Application.Features.Characters.Requests.Queries;
using Character_Management.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Character_Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CharacterController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<CharacterController>
        [HttpGet]
        public async Task<ActionResult<List<CharacterDto>>> Get()
        {
            var characters = await _mediator.Send(new GetCharacterListRequest());
            return Ok(characters);   
        }

        // GET api/<CharacterController>/5
        [HttpGet("{id}")] 
        public async Task<ActionResult<CharacterDto>> Get(int id)
        {
            var character = await _mediator.Send(new GetCharacterDetailRequest {ID = id });
            return Ok(character);
        }

        // POST api/<CharacterController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateCharacterDto createCharacterDto)
        {
            var command = new CreateCharacterCommand { CreateCharacterDto = createCharacterDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<CharacterController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateCharacterDto updateCharacterDto)
        {
            var command = new UpdateCharacterCommand {ID=id, UpdateCharacterDto = updateCharacterDto };
            await _mediator.Send(command);
            return NoContent();
        }
        // PUT api/<CharacterController>/changeapproval/5
        [HttpPut("changeapproval/{id}")]
        public async Task<ActionResult> ChangeApproval(int id , [FromBody] ChangeCharacterApprovalDto changeCharacterApprovalDto)
        {
            var command = new UpdateCharacterCommand { ID = id, ChangeCharacterApprovalDto = changeCharacterApprovalDto };
            await _mediator.Send(command);
            return NoContent();

        }

        // DELETE api/<CharacterController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCharacterCommand { ID = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
