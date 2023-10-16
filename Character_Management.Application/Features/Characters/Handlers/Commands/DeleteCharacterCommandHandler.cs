using AutoMapper;
using Character_Management.Application.Contracts.Persistence;
using Character_Management.Application.Exceptions;
using Character_Management.Application.Features.Characters.Requests.Commands;
using Character_Management.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Character_Management.Application.Features.Characters.Handlers.Commands
{
    public class DeleteCharacterCommandHandler:IRequestHandler<DeleteCharacterCommand,Unit>
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;

        public DeleteCharacterCommandHandler(ICharacterRepository characterRepository , IMapper mapper)
        {
            this._characterRepository = characterRepository;
            this._mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCharacterCommand request, CancellationToken cancellationToken)
        {
            var character = await _characterRepository.Get(request.ID);
            if(character == null)
            {
                throw new NotFoundException(nameof(Character), request.ID);
            }
            await _characterRepository.Delete(character);
            return Unit.Value;
        }
    }
}
