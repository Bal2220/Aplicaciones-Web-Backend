using RetoSem11.Management.Domain.Models.Entities;

namespace RetoSem11.Management.Interfaces.REST.Resources;

public record OperationResource(int Id, string Title, string Description, workType Type, DateTime Date, bool Status);