using AutoMapper;
using Character_Management.Application.Features.Characters.Requests.Commands;
using Character_Management.Application.persistance.contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Character_Management.Application.Features.Characters.Handlers.Commands
{
    public class UpdateCharacterCommandHandler : IRequestHandler<UpdateCharacterCommand,Unit>
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;

        public UpdateCharacterCommandHandler(ICharacterRepository characterRepository , IMapper mapper)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCharacterCommand request, CancellationToken cancellationToken)
        {
            if(request.UpdateCharacterDto != null)
            {
                var character = await _characterRepository.Get(request.UpdateCharacterDto.ID);
                _mapper.Map(request.UpdateCharacterDto, character);
                await _characterRepository.Update(character);
            }
            else if(request.ChangeCharacterApprovalDto != null)
            {

            }
           
            return Unit.Value;
        }
    }
}
