using Character_Management.MVC.Models;
using Character_Management.MVC.Services.Base;

namespace Character_Management.MVC.Contracts
{
    public interface ICharacterTypeService
    {
        Task<List<CharacterTypeVM>> GetCharacterTypes();

        Task<CharacterTypeVM> GetCharacterTypeDetails(int id);

        Task<Response<int>> CreateCharacterType(CreateCharacterTypeVM characterType);

        Task<Response<int>> UpdateCharacterType(int id , CharacterTypeVM characterType);

        Task<Response<int>> DeleteLeaveType(int id);
    }
}
