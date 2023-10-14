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
    public class DeleteCharacterTypeCommandHandler : IRequestHandler<DeleteCharacterTypeCommand, Unit>
    {
        private readonly ICharacterTypeRepository _characterTypeRepository;
        private readonly IMapper _mapper;

        public DeleteCharacterTypeCommandHandler(ICharacterTypeRepository characterTypeRepository , IMapper mapper)
        {
            this._characterTypeRepository = characterTypeRepository;
            this._mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteCharacterTypeCommand request, CancellationToken cancellationToken)
        {
            var characterType = await _characterTypeRepository.Get(request.ID);
            await _characterTypeRepository.Delete(characterType);
            return Unit.Value;
        }
    }
}
