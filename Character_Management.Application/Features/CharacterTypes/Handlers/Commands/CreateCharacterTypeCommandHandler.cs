using AutoMapper;
using Character_Management.Application.DTOs.CharacterType.Validators;
using Character_Management.Application.Exceptions;
using Character_Management.Application.Features.CharacterTypes.Requests.Commands;
using Character_Management.Application.persistance.contracts;
using Character_Management.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Character_Management.Application.Features.CharacterTypes.Handlers.Commands
{
    public class CreateCharacterTypeCommandHandler : IRequestHandler<CreateCharacterTypeCommand, int>
    {
        private readonly ICharacterTypeRepository _characterTypeRepository;
        private readonly IMapper _mapper;

        public CreateCharacterTypeCommandHandler(ICharacterTypeRepository characterTypeRepository , IMapper mapper)
        {
           _characterTypeRepository = characterTypeRepository;
           _mapper = mapper;
        }
        public async Task<int> Handle(CreateCharacterTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCharacterTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateCharacterTypeDto);
            if (validationResult.IsValid)
            {
                throw new ValidationException(validationResult) ;
            }
            var characterType = _mapper.Map<CharacterType>(request.CreateCharacterTypeDto);
            characterType = await _characterTypeRepository.Add(characterType);
            return characterType.ID;
        }
    }
}
