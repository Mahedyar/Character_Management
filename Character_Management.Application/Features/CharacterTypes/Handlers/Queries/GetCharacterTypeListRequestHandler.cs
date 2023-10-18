using AutoMapper;
using Character_Management.Application.Contracts.Persistence;
using Character_Management.Application.DTOs.CharacterType;
using Character_Management.Application.Features.CharacterTypes.Requests.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Character_Management.Application.Features.CharacterTypes.Handlers.Queries
{
    public class GetCharacterTypeListRequestHandler : IRequestHandler<GetCharacterTypeListRequest, List<CharacterTypeDto>>
    {
        private readonly ICharacterTypeRepository _characterTypeRepository;
        private readonly IMapper _mapper;

        public GetCharacterTypeListRequestHandler(ICharacterTypeRepository characterTypeRepository,IMapper mapper)
        {
            _characterTypeRepository = characterTypeRepository;
            _mapper = mapper;
        }
        public async Task<List<CharacterTypeDto>> Handle(GetCharacterTypeListRequest request, CancellationToken cancellationToken)
        {
            var characterTypeList = await _characterTypeRepository.GetAll();
            return _mapper.Map<List<CharacterTypeDto>>(characterTypeList);
        }
    }
}
