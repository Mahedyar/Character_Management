using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Application.Features.Characters.Requests.Commands
{
    public class DeleteCharacterCommand:IRequest<Unit>
    {
        public int ID { get; set; }
    }
}
