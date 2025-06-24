namespace RetoSem11.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}