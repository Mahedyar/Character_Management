using AutoMapper;
using Character_Management.Application.Features.Characters.Requests.Commands;
using Character_Management.Application.persistance.contracts;
using Character_Management.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Character_Management.Application.Features.Characters.Handlers.Commands
{
    public class CreateCharacterTypeCommandHandler : IRequestHandler<CreateCharacterCommand, int>
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;

        public CreateCharacterTypeCommandHandler(ICharacterRepository characterRepository , IMapper mapper)
        {
           _characterRepository = characterRepository;
           _mapper = mapper;
        }
        public async Task<int> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
        {
            var character = _mapper.Map<Character>(request.CreateCharacterDto);
            character = await _characterRepository.Add(character);
            return character.ID;
        }
    }
}
