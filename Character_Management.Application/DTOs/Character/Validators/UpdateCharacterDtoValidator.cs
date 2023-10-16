using Character_Management.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Application.DTOs.Character.Validators
{
    public class UpdateCharacterDtoValidator:AbstractValidator<UpdateCharacterDto>
    {

        //private readonly ICharacterTypeRepository _characterTypeRepository;
        public UpdateCharacterDtoValidator(ICharacterTypeRepository characterTypeRepository)
        {
            //_characterTypeRepository = characterTypeRepository;
            Include(new ICharacterDtoValidator(characterTypeRepository));
            
        }
    }
}
