using AutoMapper;
using Character_Management.Application.Contracts.Persistence;
using Character_Management.Application.Features.Characters.Requests.Queries;
using Character_Management.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Character_Management.Application.Features.Characters.Handlers.Queries
{
    public class GetCharacterListRequestHandler : IRequestHandler<GetCharacterListRequest, List<CharacterDto>>
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;

        public GetCharacterListRequestHandler(ICharacterRepository characterRepository,IMapper mapper)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
        }
        public async Task<List<CharacterDto>> Handle(GetCharacterListRequest request, CancellationToken cancellationToken)
        {
            var characterList = await _characterRepository.GetAll();
            return _mapper.Map<List<CharacterDto>>(characterList);
        }
    }
}
