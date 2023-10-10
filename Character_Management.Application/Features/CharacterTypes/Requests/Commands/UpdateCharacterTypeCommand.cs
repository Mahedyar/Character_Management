using Character_Management.Application.DTOs.CharacterType;
using MediatR;

namespace Character_Management.Application.Features.CharacterTypes.Requests.Commands
{
    public class UpdateCharacterTypeCommand:IRequest<Unit>
    {
        public UpdateCharacterTypeDto UpdateCharacterTypeDto { get; set; }
    }
}
