using AutoMapper;
using Character_Management.Application.Contracts.Persistence;
using Character_Management.Application.Features.Characters.Requests.Queries;
using Character_Management.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Character_Management.Application.Features.Characters.Handlers.Queries
{
    public class GetCharacterDetailRequestHandler : IRequestHandler<GetCharacterDetailRequest, CharacterDto>
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;

        public GetCharacterDetailRequestHandler(ICharacterRepository characterRepository , IMapper mapper)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
        }
        public async Task<CharacterDto> Handle(GetCharacterDetailRequest request, CancellationToken cancellationToken)
        {
            //var character = await _characterRepository.Get(request.Id);
            var character = await _characterRepository.GetSingleCharacterWithDetails(request.Id);
            return _mapper.Map<CharacterDto>(character);
        }
    }
}
