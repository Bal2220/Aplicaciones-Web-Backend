using RetoSem11.Shared.Domain.Repositories;
using RetoSem11.Shared.Infraestructure.Persistence.Configuration;

namespace RetoSem11.Shared.Infraestructure.Persistence.Repositories;

public class UnitOfWork(OperationContext context) : IUnitOfWork
{
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}