namespace RetoSem10.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}