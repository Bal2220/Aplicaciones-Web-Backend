using RetoSem11.Management.Domain.Models.Entities;

namespace RetoSem11.Management.Domain.Models.Commands;

public record CreateOperationCommand(string Title, string Description, workType Type, DateTime Date, bool Status);