using Character_Management.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Application.Features.Characters.Requests.Queries
{
    public class GetCharacterListRequest :IRequest<List<CharacterDto>>
    {

    }
}
