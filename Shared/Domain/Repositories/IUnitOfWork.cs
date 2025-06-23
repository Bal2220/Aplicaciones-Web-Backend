namespace RetoSem9.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}