namespace RetoSem10.Operations.Domain.Models.Exceptions;

public class NotOperationsFoundExceptions : Exception
{
    public NotOperationsFoundExceptions() : base("Not Operations Found") {}
    
    public NotOperationsFoundExceptions(string message) : base(message) {}
    
    public NotOperationsFoundExceptions(string message, Exception innerException) : base(message, innerException) {}
}