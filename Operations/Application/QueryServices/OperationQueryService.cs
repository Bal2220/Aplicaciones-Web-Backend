using RetoSem10.Operations.Domain;
using RetoSem10.Operations.Domain.Models.Entities;
using RetoSem10.Operations.Domain.Models.Queries;
using RetoSem10.Operations.Domain.Services;
using RetoSem10.Shared.Domain.Repositories;

namespace RetoSem10.Operations.Application.QueryServices
{
    public class OperationQueryService : IOperationQueryService
    {
        private readonly IOperationRepository _operationRepository;

        public OperationQueryService(IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository ?? throw new ArgumentNullException(nameof(operationRepository));
        }

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