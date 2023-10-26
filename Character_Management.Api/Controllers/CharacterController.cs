using Character_Management.Application.DTOs.Character;
using Character_Management.Application.Features.Characters.Requests.Commands;
using Character_Management.Application.Features.Characters.Requests.Queries;
using Character_Management.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?Linkid=397860

namespace Character_Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        [HttpGet("{Id}")] 
        public async Task<ActionResult<CharacterDto>> Get(int Id)
        {
            var character = await _mediator.Send(new GetCharacterDetailRequest {Id = Id });
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
        [HttpPut("{Id}")]
        public async Task<ActionResult> Put(int Id, [FromBody] UpdateCharacterDto updateCharacterDto)
        {
            var command = new UpdateCharacterCommand {Id=Id, UpdateCharacterDto = updateCharacterDto };
            await _mediator.Send(command);
            return NoContent();
        }
        // PUT api/<CharacterController>/changeapproval/5
        [HttpPut("changeapproval/{Id}")]
        public async Task<ActionResult> ChangeApproval(int Id , [FromBody] ChangeCharacterApprovalDto changeCharacterApprovalDto)
        {
            var command = new UpdateCharacterCommand { Id = Id, ChangeCharacterApprovalDto = changeCharacterApprovalDto };
            await _mediator.Send(command);
            return NoContent();

        }

        // DELETE api/<CharacterController>/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var command = new DeleteCharacterCommand { Id = Id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
