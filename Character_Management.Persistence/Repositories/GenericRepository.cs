using Character_Management.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Character_Management.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CharacterManagementDbContext _context;

        public GenericRepository(CharacterManagementDbContext context)
        {
            _context = context;
        }
        public async Task<T> Add(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            //_context.Remove(entity);

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exist(int ID)
        {
            var entity = await Get(ID);
            return entity != null;
        }

        public async Task<T> Get(int ID)
        {
            return await _context.Set<T>().FindAsync(ID);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Update(T entity)
        {

            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
