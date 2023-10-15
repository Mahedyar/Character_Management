using AutoMapper;
using Character_Management.Application.DTOs.Character.Validators;
using Character_Management.Application.Exceptions;
using Character_Management.Application.Features.Characters.Requests.Commands;
using Character_Management.Application.persistance.contracts;
using Character_Management.Application.Responses;
using Character_Management.Domain;
using FluentValidation.Internal;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Character_Management.Application.Features.Characters.Handlers.Commands
{
    public class CreateCharacterTypeCommandHandler : IRequestHandler<CreateCharacterCommand, BaseCommandResponse>
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly ICharacterTypeRepository _characterTypeRepository;
        private readonly IMapper _mapper;

        public CreateCharacterTypeCommandHandler(ICharacterRepository characterRepository,ICharacterTypeRepository characterTypeRepository , IMapper mapper)
        {
           _characterRepository = characterRepository;
           _characterTypeRepository = characterTypeRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCharacterDtoValidator(_characterTypeRepository);
            var validationResult = await validator.ValidateAsync(request.CreateCharacterDto);
            if(validationResult.IsValid == false)
            {
                //throw new ValidationException(validationResult);
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var character = _mapper.Map<Character>(request.CreateCharacterDto);
            character = await _characterRepository.Add(character);
            response.Success = true;
            response.Message = "Creation Successful";
            response.ID = character.ID;
            return response;
        }
    }
}
