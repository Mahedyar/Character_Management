using Character_Management.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Application.Features.CharacterTypes.Requests.Queries
{
    public class GetCharacterTypeListRequest :IRequest<List<CharacterTypeDto>>
    {

    }
}
