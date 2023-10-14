using AutoMapper;
using Character_Management.Application.DTOs.Character.Validators;
using Character_Management.Application.Features.Characters.Requests.Commands;
using Character_Management.Application.persistance.contracts;
using Character_Management.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Character_Management.Application.Features.Characters.Handlers.Commands
{
    public class CreateCharacterTypeCommandHandler : IRequestHandler<CreateCharacterCommand, int>
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly ICharacterTypeRepository _characterTypeRepository;
        private readonly IMapper _mapper;

        public CreateCharacterTypeCommandHandler(ICharacterRepository characterRepository,ICharacterTypeRepository characterTypeRepository , IMapper mapper)
        {
           _characterRepository = characterRepository;
            this._characterTypeRepository = characterTypeRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCharacterDtoValidator(_characterTypeRepository);
            var validationResult = await validator.ValidateAsync(request.CreateCharacterDto);
            if(validationResult.IsValid == false)
            {
                throw new Exception();
            }

            var character = _mapper.Map<Character>(request.CreateCharacterDto);
            character = await _characterRepository.Add(character);
            return character.ID;
        }
    }
}
