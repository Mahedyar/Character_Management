using Character_Management.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Character_Management.Application.Contracts.Persistence
{
    public interface ICharacterRepository : IGenericRepository<Character>
    {
        Task<List<Character>> GetCharactersWithDetails();
        Task<Character> GetSingleCharacterWithDetails(int Id);

        Task ChangeApprovalStatus(Character character, bool? approvalStatus);
    }
}
