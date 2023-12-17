using blogCSharp.Context;
using blogCSharp.Models;
using blogCSharp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace blogCSharp.Repository.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
    {
        public readonly DbSet<TEntity> DbSet;
        public readonly BlogDbContext Context;

        public RepositoryBase(BlogDbContext context)
        {
            DbSet = context.Set<TEntity>();
            Context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<IList<TEntity>> All() =>
            await DbSet.ToListAsync();

        public async Task<TEntity> GetPerId(Guid id) =>
            await DbSet.FindAsync(id);

        public async Task Remove(Guid id)
        {
            var entityToRemove = await GetPerId(id);
            DbSet.Remove(entityToRemove);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            await Context.SaveChangesAsync();
        }
    }
}