using AutoMapper;
using Character_Management.Application.DTOs.Character.Validators;
using Character_Management.Application.Exceptions;
using Character_Management.Application.Features.Characters.Requests.Commands;
using Character_Management.Application.persistance.contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Character_Management.Application.Features.Characters.Handlers.Commands
{
    public class UpdateCharacterCommandHandler : IRequestHandler<UpdateCharacterCommand, Unit>
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;
        private readonly ICharacterTypeRepository _characterTypeRepository;

        public UpdateCharacterCommandHandler(ICharacterRepository characterRepository, IMapper mapper, ICharacterTypeRepository characterTypeRepository)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
            _characterTypeRepository = characterTypeRepository;
        }

        public async Task<Unit> Handle(UpdateCharacterCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCharacterDtoValidator(_characterTypeRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateCharacterDto);
            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            var character = await _characterRepository.Get(request.ID);
            if (request.UpdateCharacterDto != null)
            {

                _mapper.Map(request.UpdateCharacterDto, character);
                await _characterRepository.Update(character);
            }
            else if (request.ChangeCharacterApprovalDto != null)
            {
                await _characterRepository.ChangeApprovalStatus(character, request.ChangeCharacterApprovalDto.Approved);
            }

            return Unit.Value;
        }
    }
}
