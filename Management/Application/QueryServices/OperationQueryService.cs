using RetoSem11.Management.Domain;
using RetoSem11.Management.Domain.Models.Entities;
using RetoSem11.Management.Domain.Models.Queries;
using RetoSem11.Management.Domain.Services;

namespace RetoSem11.Management.Application.QueryServices
{
    public class OperationQueryService(IOperationRepository operationRepository) : IOperationQueryService 
    {
        private readonly IOperationRepository _operationRepository = operationRepository ?? throw new ArgumentNullException(nameof(operationRepository));
        
        public async Task<IEnumerable<Operation>> Handle(GetAllOperationsQuery query)
        {
            var operations = await _operationRepository.ListAsync();
            return operations.Where(op => op.IsActive);
        }
        
        public async Task<Operation?> Handle(GetOperationByIdQuery query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            var book = await _operationRepository.FindByIdAsync(query.OperationId);
            return book?.IsActive == true ? book : null;
        }
    }
}