using AutoMapper;
using Character_Management.Application.Contracts.Persistence;
using Character_Management.Application.DTOs.CharacterType.Validators;
using Character_Management.Application.Exceptions;
using Character_Management.Application.Features.CharacterTypes.Requests.Commands;
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
            var validator = new UpdateCharacterTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateCharacterTypeDto);
            if(validationResult != null)
            {
                throw new ValidationException(validationResult);
            }
            var characterType = await _characterTypeRepository.Get(request.UpdateCharacterTypeDto.ID);
            _mapper.Map(request.UpdateCharacterTypeDto, characterType);
            await _characterTypeRepository.Update(characterType);
            return Unit.Value;
        }
    }
}
