namespace RetoSem10.Operations.Domain.Models.Commands;

public record UpdateOperationCommand(int Id, string Title, string Type, DateTime Date, bool Status);