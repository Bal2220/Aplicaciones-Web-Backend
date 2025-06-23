using RetoSem9.Shared.Domain.Repositories;
using RetoSem9.Shared.Infraestructure.Persistence.Configuration;

namespace RetoSem9.Shared.Infraestructure.Persistence.Repositories;

public class UnitOfWork(CenterContext context) : IUnitOfWork
{
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}