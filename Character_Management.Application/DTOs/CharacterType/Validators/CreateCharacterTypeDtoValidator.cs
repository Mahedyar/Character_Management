using FluentValidation;

namespace Character_Management.Application.DTOs.CharacterType.Validators
{
    public class CreateCharacterTypeDtoValidator :AbstractValidator<CreateCharacterTypeDto>
    {
        public CreateCharacterTypeDtoValidator()
        {
            Include(new ICharacterTypeDtoValidator());
        }
    }
}
