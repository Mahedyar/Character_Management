using AutoMapper;
using Character_Management.Application.Features.CharacterTypes.Requests.Commands;
using Character_Management.Application.persistance.contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Character_Management.Application.Features.CharacterTypes.Handlers.Commands
{
    public class UpdateCharacterTypeCommandHandler : IRequestHandler<UpdateCharacterTypeCommand,Unit>
    {
        private readonly ICharacterTypeRepository _characterTypeRepository;
        private readonly IMapper _mapper;

        public UpdateCharacterTypeCommandHandler(ICharacterTypeRepository characterType , IMapper mapper)
        {
            _characterTypeRepository = characterType;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCharacterTypeCommand request, CancellationToken cancellationToken)
        {
            var characterType = await _characterTypeRepository.Get(request.UpdateCharacterTypeDto.ID);
            _mapper.Map(request.UpdateCharacterTypeDto, characterType);
            await _characterTypeRepository.Update(characterType);
            return Unit.Value;
        }
    }
}
