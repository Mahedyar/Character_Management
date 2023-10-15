using Character_Management.Application.DTOs.Character;
using Character_Management.Application.Responses;
using Character_Management.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Application.Features.Characters.Requests.Commands
{
    public class CreateCharacterCommand:IRequest<BaseCommandResponse>
    {
        public CreateCharacterDto CreateCharacterDto {  get; set; }
    }
}
