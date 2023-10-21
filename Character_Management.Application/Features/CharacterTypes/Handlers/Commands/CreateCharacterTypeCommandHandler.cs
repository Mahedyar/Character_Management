using AutoMapper;
using Character_Management.Application.Contracts.Persistence;
using Character_Management.Application.DTOs.CharacterType.Validators;
using Character_Management.Application.Features.CharacterTypes.Requests.Commands;
using Character_Management.Application.Responses;
using Character_Management.Domain;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Character_Management.Application.Features.CharacterTypes.Handlers.Commands
{
    public class CreateCharacterTypeCommandHandler : IRequestHandler<CreateCharacterTypeCommand, BaseCommandResponse>
    {
        private readonly ICharacterTypeRepository _characterTypeRepository;
        private readonly IMapper _mapper;

        public CreateCharacterTypeCommandHandler(ICharacterTypeRepository characterTypeRepository , IMapper mapper)
        {
           _characterTypeRepository = characterTypeRepository;
           _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateCharacterTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCharacterTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateCharacterTypeDto);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var characterType = _mapper.Map<CharacterType>(request.CreateCharacterTypeDto);
                characterType = await _characterTypeRepository.Add(characterType);
                response.Success = true;
                response.Message = "Creation Successful";
            }
            return response;
           
        }
    }
}
