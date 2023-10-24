using Character_Management.Application.DTOs.Character;
using MediatR;

namespace Character_Management.Application.Features.Characters.Requests.Commands
{
    public class UpdateCharacterCommand:IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateCharacterDto UpdateCharacterDto { get; set; }

        public ChangeCharacterApprovalDto ChangeCharacterApprovalDto { get; set; }
    }
}
