using Character_Management.Application.DTOs.CharacterType;
using Character_Management.Application.Responses;
using Character_Management.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Application.Features.CharacterTypes.Requests.Commands
{
    public class CreateCharacterTypeCommand:IRequest<BaseCommandResponse>
    {
        public CreateCharacterTypeDto CreateCharacterTypeDto {  get; set; }
    }
}
