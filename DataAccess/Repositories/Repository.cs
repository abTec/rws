using Application.Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly AppDbContext Context;
        private DbSet<TEntity> _dbSet;

        public Repository(AppDbContext context)
        {
            Context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<ICollection<TEntity>> GetAll() => await _dbSet.ToListAsync();

        public virtual async Task<bool> Create(TEntity entity)
        {
            _dbSet.Add(entity);
            return await Context.SaveChangesAsync() > 0;
        }

        public async Task Delete(int id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) return;

            _dbSet.Remove(entity);

            await Context.SaveChangesAsync();
        }
    }
}