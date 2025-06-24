using RetoSem11.Shared.Domain.Repositories;
using RetoSem11.Shared.Infraestructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace RetoSem11.Shared.Infraestructure.Persistence.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly OperationContext Context;

    protected BaseRepository(OperationContext context)
    {
        Context = context;
    }

    public async Task AddAsync(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
    }
    
    public async Task<TEntity?> FindByIdAsync(int id)
    {
        return await Context.Set<TEntity>().FindAsync(id);
    }
    
    public void Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
    }
    
    public void Remove(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }
    
    public async Task<IEnumerable<TEntity>> ListAsync()
    {
        return await Context.Set<TEntity>().ToListAsync();
    }
}