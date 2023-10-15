using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Character_Management.Application.persistance.contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int ID);
        Task<IReadOnlyList<T>> GetAll();
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<bool> Exist(int ID);
    }
}
