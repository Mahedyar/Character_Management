using AutoMapper;
using Character_Management.Application.Contracts.Persistence;
using Character_Management.Application.DTOs.CharacterType;
using Character_Management.Application.Features.CharacterTypes.Handlers.Commands;
using Character_Management.Application.Features.CharacterTypes.Requests.Commands;
using Character_Management.Application.profiles;
using Character_Management.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character_Management.Application.UnitTests.CharacterTypes.Commands
{
    public class CreateCharacterTypeCommandHandlerTests
    {
       private readonly IMapper _mapper;
       readonly Mock<ICharacterTypeRepository> _mockCharactertTypeRepository;
       readonly CreateCharacterTypeDto _createCharacterTypeDto;
        public CreateCharacterTypeCommandHandlerTests()
        {
            _mockCharactertTypeRepository = MockCharacterTypeRepository.GetCharacterTypeRepository();
            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _createCharacterTypeDto = new CreateCharacterTypeDto { Type = "Safir" };
        }

        [Fact]

        public async Task CreateCharacterTypeTest()
        {
            var handler = new CreateCharacterTypeCommandHandler(_mockCharactertTypeRepository.Object , _mapper);
            var result = await handler.Handle(new CreateCharacterTypeCommand() {CreateCharacterTypeDto = _createCharacterTypeDto}, CancellationToken.None);

            result.ShouldBeOfType<int>();

            var characterTypes = await _mockCharactertTypeRepository.Object.GetAll();

            characterTypes.Count.ShouldBe(3);
            
            
        }

    }
}
