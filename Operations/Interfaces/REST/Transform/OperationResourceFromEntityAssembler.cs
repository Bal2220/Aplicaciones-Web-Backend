using RetoSem10.Operations.Domain.Models.Commands;
using RetoSem10.Operations.Domain.Models.Entities;
using RetoSem10.Operations.Interfaces.REST.Resources;

namespace RetoSem10.Operations.Interfaces.REST.Transform;

public static class OperationResourceFromEntityAssembler
{
    public static OperationResource ToResourceFromEntity(Operation operation)
    {
        return new OperationResource(operation.Id, operation.Title, operation.Type, operation.Date, operation.StatusText);
    }
}