using FluentValidation;

namespace Character_Management.Application.DTOs.CharacterType.Validators
{
    public class UpdateCharacterTypeDtoValidator:AbstractValidator<UpdateCharacterTypeDto>
    {
        public UpdateCharacterTypeDtoValidator()
        {
            Include(new ICharacterTypeDtoValidator());
        }
    }
}
