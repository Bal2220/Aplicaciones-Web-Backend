using RetoSem10.Operations.Domain.Models.Commands;
using RetoSem10.Operations.Domain.Models.Entities;

namespace RetoSem10.Operations.Domain.Services;

public interface IOperationCommandService
{
    Task<Operation> Handle(CreateOperationCommand command);
    Task<bool> Handle(DeleteOperationCommand command);
}