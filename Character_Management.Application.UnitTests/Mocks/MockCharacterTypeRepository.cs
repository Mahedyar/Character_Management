using Character_Management.Application.Contracts.Persistence;
using Character_Management.Domain;
using Moq;

namespace Character_Management.Application.UnitTests.Mocks
{
    public class MockCharacterTypeRepository
    {
        public static Mock<ICharacterTypeRepository> GetCharacterTypeRepository()
        {
            var characterTypes = new List<CharacterType>()
            {
                new CharacterType
                {
                    Id =1,
                    Type = "Test AshrafZade"
                },
                new CharacterType
                {
                    Id=2,
                    Type = "Test Jangju"
                }
            };

            var mockRepo = new Mock<ICharacterTypeRepository>();
            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(characterTypes);

            mockRepo.Setup(r => r.Add(It.IsAny<CharacterType>())).ReturnsAsync((CharacterType characterType) =>
            {
                characterTypes.Add(characterType);
                return characterType;
            });

            return mockRepo;
        }
    }
}
