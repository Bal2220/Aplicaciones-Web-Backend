namespace RetoSem10.Operations.Domain.Models.Commands;

public record CreateOperationCommand(string Title, string Type, DateTime Date, bool Status);