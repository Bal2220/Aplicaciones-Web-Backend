using RetoSem10.Operations.Domain;
using RetoSem10.Operations.Domain.Models.Commands;
using RetoSem10.Operations.Domain.Models.Entities;
using RetoSem10.Operations.Domain.Services;
using RetoSem10.Shared.Domain.Repositories;

namespace RetoSem10.Operations.Application.CommandServices
{
    public class OperationCommandService(IOperationRepository operationRepository, IUnitOfWork unitOfWork) : IOperationCommandService
    {
        private readonly IOperationRepository _operationRepository = operationRepository ?? throw new ArgumentNullException(nameof(operationRepository));
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        public async Task<Operation> Handle(CreateOperationCommand command)
        {
            ArgumentNullException.ThrowIfNull(command);
            
            var operation = new Operation(command.Title, command.Type, command.Date, command.Status);
            
            if (command.Date > DateTime.Now) throw new ArgumentException("La fecha no puede estar en el futuro");
            
            await _operationRepository.AddAsync(operation);
            await _unitOfWork.CompleteAsync();
            
            return operation;
        }

        public async Task<bool> Handle(DeleteOperationCommand command)
        {
            ArgumentNullException.ThrowIfNull(command);
            
            var operation = await _operationRepository.FindByIdAsync(command.Id);
            if (operation is null) return false;

            if (!operation.Status)
                throw new InvalidOperationException("Solo se pueden eliminar operaciones completadas");
            
            if ((DateTime.Now - operation.Date).TotalDays < 30)
                throw new InvalidOperationException("Solo se pueden eliminar operaciones completadas hace más de 30 días");
            
            operation.IsActive = false;
            operation.ModifiedDate = DateTime.Now;

            _operationRepository.Update(operation);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}