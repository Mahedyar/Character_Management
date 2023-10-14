using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Application.DTOs.CharacterType.Validators
{
    public class ICharacterTypeDtoValidator:AbstractValidator<ICharacterTypeDto>
    {
        public ICharacterTypeDtoValidator()
        {
            RuleFor(p => p.Type).NotEmpty().NotNull().WithMessage("Please enter {PropertyName} ");
        }
    }
}
