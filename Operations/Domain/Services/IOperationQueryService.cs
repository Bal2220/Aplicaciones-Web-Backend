using RetoSem10.Operations.Domain.Models.Entities;
using RetoSem10.Operations.Domain.Models.Queries;

namespace RetoSem10.Operations.Domain.Services;

public interface IOperationQueryService
{
    Task<IEnumerable<Operation>> Handle(GetAllOperationsQuery query);
    Task<Operation> Handle(GetOperationByIdQuery query);
}