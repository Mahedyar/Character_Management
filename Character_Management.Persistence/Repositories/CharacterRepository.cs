using Character_Management.Application.Contracts.Persistence;
using Character_Management.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Character_Management.Persistence.Repositories
{
    public class CharacterRepository:GenericRepository<Character>,ICharacterRepository
    {
        private readonly CharacterManagementDbContext _context;

        public CharacterRepository(CharacterManagementDbContext context):base(context)
        {
            _context = context;
        }

        public async Task ChangeApprovalStatus(Character character, bool? approvalStatus)
        {
            character.Approved = approvalStatus;
            _context.Update(character);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Character>> GetCharactersWithDetails() 
        {
            var characters = await _context.Characters.Include(c => c.CharacterType).ToListAsync();
            return characters;
        }

        public async Task<Character> GetSingleCharacterWithDetails(int id)
        {
            var character = await _context.Characters.Include(c => c.CharacterType).SingleOrDefaultAsync(c=>c.ID == id);
            return character;
        }
    }
}
