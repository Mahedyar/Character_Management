using Character_Management.Application.DTOs.CharacterType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Application.Features.CharacterTypes.Requests.Queries
{
    public class GetCharacterTypeDetailRequest:IRequest<CharacterTypeDto>
    {
        public int ID { get; set; }
    }
}
