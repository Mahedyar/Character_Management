using AutoMapper;
using Character_Management.Application.DTOs.CharacterType;
using Character_Management.Application.Features.CharacterTypes.Requests.Queries;
using Character_Management.Application.persistance.contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Character_Management.Application.Features.CharacterTypes.Handlers.Queries
{
    public class GetCharacterTypeDetailRequestHandler : IRequestHandler<GetCharacterTypeDetailRequest, CreateCharacterTypeDto>
    {
        private readonly ICharacterTypeRepository _characterTypeRepository;
        private readonly IMapper _mapper;

        public GetCharacterTypeDetailRequestHandler(ICharacterTypeRepository characterTypeRepository , IMapper mapper)
        {
            _characterTypeRepository = characterTypeRepository;
            _mapper = mapper;
        }
        public async Task<CreateCharacterTypeDto> Handle(GetCharacterTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var characterType = await _characterTypeRepository.Get(request.ID);
            return _mapper.Map<CreateCharacterTypeDto>(characterType);
        }
    }
}
