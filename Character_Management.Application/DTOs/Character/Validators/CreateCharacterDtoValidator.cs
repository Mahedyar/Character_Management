using Character_Management.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Application.DTOs.Character.Validators
{
    public class CreateCharacterDtoValidator:AbstractValidator<CreateCharacterDto>
    {
        private readonly ICharacterTypeRepository _characterTypeRepository;

        public CreateCharacterDtoValidator(ICharacterTypeRepository characterTypeRepository)
        {
            _characterTypeRepository = characterTypeRepository;
            Include(new ICharacterDtoValidator(_characterTypeRepository));

            RuleFor(p => p.RequestDate).NotNull().NotEmpty();
            
        }
    }
}
