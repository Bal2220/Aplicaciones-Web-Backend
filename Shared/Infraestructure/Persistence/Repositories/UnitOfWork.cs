using RetoSem10.Shared.Domain.Repositories;
using RetoSem10.Shared.Infraestructure.Persistence.Configuration;

namespace RetoSem10.Shared.Infraestructure.Persistence.Repositories;

public class UnitOfWork(OperationsContext context) : IUnitOfWork
{
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}