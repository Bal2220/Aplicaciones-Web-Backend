using Microsoft.EntityFrameworkCore;
using RetoSem10.Shared.Domain.Repositories;
using RetoSem10.Shared.Infraestructure.Persistence.Configuration;

namespace RetoSem10.Shared.Infraestructure.Persistence.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly OperationsContext Context;

    protected BaseRepository(OperationsContext context)
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