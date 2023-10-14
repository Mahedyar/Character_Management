using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Application.Features.CharacterTypes.Requests.Commands
{
    public class DeleteCharacterTypeCommand:IRequest<Unit>
    {
        public int ID { get; set; }
    }
}
