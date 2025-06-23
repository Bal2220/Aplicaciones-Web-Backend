using RetoSem9.Shared.Domain.Repositories;
using RetoSem9.Shared.Infraestructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using RetoSem9.Catalog.Domain.Models.Entities;

namespace RetoSem9.Shared.Infraestructure.Persistence.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly CenterContext Context;
    
    protected BaseRepository(CenterContext context)
    {
        Context = context;
    }
    
    public async Task AddAsync(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
    }
    
    public async Task<IEnumerable<TEntity>> ListAsync()
    {
        return await Context.Set<TEntity>().ToListAsync();
    }
}