using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity> Create(TEntity entity);
        Task Delete(int id);
        Task<ICollection<TEntity>> GetAll();
    }
}