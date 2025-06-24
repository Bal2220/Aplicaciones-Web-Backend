using RetoSem11.Management.Domain.Models.Entities;
using RetoSem11.Management.Interfaces.REST.Resources;

namespace RetoSem11.Management.Interfaces.REST.Transform;

public static class OperationResourceFromEntityAssembler
{
    public static OperationResource ToResourceFromEntity(Operation operation)
    {
        return new OperationResource(operation.Id, operation.Title, operation.Description, operation.Type, operation.Date, operation.Status);
    }
}