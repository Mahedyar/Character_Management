using AutoMapper;
using Character_Management.Application.Contracts.Persistence;
using Character_Management.Application.DTOs.CharacterType;
using Character_Management.Application.Features.CharacterTypes.Handlers.Queries;
using Character_Management.Application.Features.CharacterTypes.Requests.Queries;
using Character_Management.Application.profiles;
using Character_Management.Application.UnitTests.Mocks;
using Character_Management.Domain;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character_Management.Application.UnitTests.CharacterTypes.Queries
{
    public class GetCharacterTypeListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        Mock<ICharacterTypeRepository> _mockCharacterTypeRepository;

        public GetCharacterTypeListRequestHandlerTests()
        {
            
            _mockCharacterTypeRepository = MockCharacterTypeRepository.GetCharacterTypeRepository();

            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

        }

        [Fact]

        public async Task GetCharacterTypeListTest()
        {
            var handler = new GetCharacterTypeListRequestHandler(_mockCharacterTypeRepository.Object, _mapper);
            var result = await handler.Handle(new GetCharacterTypeListRequest() ,CancellationToken.None);

            result.ShouldBeOfType<List<CharacterTypeDto>>();
            result.Count.ShouldBe(2);
            
            
        }

    }
}
