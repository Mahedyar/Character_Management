using Character_Management.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Application.Features.Characters.Requests.Commands
{
    public class CreateCharacterCommand:IRequest<int>
    {
        public CharacterDto CharacterDto {  get; set; }
    }
}
