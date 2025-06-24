using RetoSem11.Management.Domain.Models.Entities;

namespace RetoSem11.Management.Domain.Models.Commands;

public record UpdateOperationCommand(int Id, string Title, string Description, workType Type, DateTime Date, bool Status);