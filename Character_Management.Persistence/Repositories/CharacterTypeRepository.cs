using Character_Management.Application.Contracts.Persistence;
using Character_Management.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Persistence.Repositories
{
    public class CharacterTypeRepository:GenericRepository<CharacterType> , ICharacterTypeRepository
    {
        private readonly CharacterManagementDbContext _context;

        public CharacterTypeRepository(CharacterManagementDbContext context):base(context)
        {
            _context = context;
        }
    }
}
