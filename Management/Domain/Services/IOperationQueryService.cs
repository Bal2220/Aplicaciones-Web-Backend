using RetoSem11.Management.Domain.Models.Entities;
using RetoSem11.Management.Domain.Models.Queries;

namespace RetoSem11.Management.Domain.Services;

public interface IOperationQueryService
{
    Task<IEnumerable<Operation>> Handle(GetAllOperationsQuery query);
    Task<Operation> Handle(GetOperationByIdQuery query);
}