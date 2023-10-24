using Character_Management.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Application.Features.Characters.Requests.Queries
{
    public class GetCharacterDetailRequest:IRequest<CharacterDto>
    {
        public int Id { get; set; }
    }
}
