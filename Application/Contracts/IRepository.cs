using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Task<bool> CreateAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<ICollection<TEntity>> GetAllAsync();
    }
}