using RetoSem11.Management.Domain.Models.Commands;
using RetoSem11.Management.Domain.Models.Entities;

namespace RetoSem11.Management.Domain.Services;

public interface IOperationCommandService
{
    Task<Operation> Handle(CreateOperationCommand command);
    Task<bool> Handle(UpdateOperationCommand command, int Id);
    Task<bool> Handle(DeleteOperationCommand command);
}