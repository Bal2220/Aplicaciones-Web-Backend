using System.Data;
using FluentValidation;
using RetoSem11.Management.Domain;
using RetoSem11.Management.Domain.Models.Commands;
using RetoSem11.Management.Domain.Models.Entities;
using RetoSem11.Management.Domain.Services;
using RetoSem11.Shared.Domain.Repositories;

namespace RetoSem11.Management.Application.CommandServices
{
    public class OperationCommandService(
        IOperationRepository operationRepository,
        IUnitOfWork unitOfWork,
        IValidator<CreateOperationCommand> validator) : IOperationCommandService
    {
        private readonly IOperationRepository _operationRepository =
            operationRepository ?? throw new ArgumentNullException(nameof(operationRepository));

        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        private readonly IValidator<CreateOperationCommand> _validator =
            validator ?? throw new ArgumentNullException(nameof(validator));
        
        // CREATE OPERATION
        public async Task<Operation> Handle(CreateOperationCommand command)
        {
            ArgumentNullException.ThrowIfNull(command);

            var validationResult = await validator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationException(string.Join(", ", errors));
            }

            var operation = new Operation(command.Title, command.Description, command.Type, command.Date, command.Status);
            
            await _operationRepository.AddAsync(operation);
            await _unitOfWork.CompleteAsync();

            return operation;
        }
        
        // UPDATE OPERATION
        public async Task<bool> Handle(UpdateOperationCommand command, int Id)
        {
            var operation = await _operationRepository.FindByIdAsync(Id);
            if (operation is null) throw new DataException("Operacion no encontrada.");
            
            operation.Title = command.Title;
            operation.Description = command.Description;
            operation.Type = command.Type;
            operation.Date = command.Date;
            operation.Status = command.Status;
            operation.ModifiedDate = DateTime.Now;

            _operationRepository.Update(operation);
            await _unitOfWork.CompleteAsync();

            return true;
        }
        
        // DELETE OPERATION
        public async Task<bool> Handle(DeleteOperationCommand command)
        {
            ArgumentNullException.ThrowIfNull(command);
            
            var operation = await _operationRepository.FindByIdAsync(command.Id);
            if (operation is null) return false;

            if (operation.Status)
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