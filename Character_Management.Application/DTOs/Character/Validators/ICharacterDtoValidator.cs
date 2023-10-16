using Character_Management.Application.Contracts.Persistence;
using FluentValidation;

namespace Character_Management.Application.DTOs.Character.Validators
{
    public class ICharacterDtoValidator : AbstractValidator<ICharacterDto>
    {
        private readonly ICharacterTypeRepository _characterTypeRepository;

        public ICharacterDtoValidator(ICharacterTypeRepository characterTypeRepository)
        {
            this._characterTypeRepository = characterTypeRepository;
            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is Required").NotNull().MaximumLength(50).WithMessage("{PropertyName} must not exceed 50")
               /* .GreaterThanOrEqualTo(p=> p.Story).WithMessage("{PropertyName} must be less than {ComparisonValue}")*/;
            RuleFor(p => p.AbilityType).NotEmpty().WithMessage("{PropertyName} should be provided").NotNull();
            RuleFor(p => p.CharacterTypeID).GreaterThan(0).MustAsync(async (id, token) =>
            {
                var characterTypeExist = await _characterTypeRepository.Exist(id);
                return !characterTypeExist;
            }).WithMessage("{PropertyName} Doesnt Exist ");

        }
    }
}
