namespace RetoSem11.Management.Domain.Models.Exceptions;

public class NotOperationFoundException : Exception
{
    public NotOperationFoundException() : base("Not operations found")
    {
    }

    public NotOperationFoundException(string message)
        : base(message)
    {
    }

    public NotOperationFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
}   