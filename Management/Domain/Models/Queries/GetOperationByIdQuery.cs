namespace RetoSem11.Management.Domain.Models.Queries
{
    public record GetOperationByIdQuery
    {
        public GetOperationByIdQuery(int operationId)
        {
            OperationId = operationId;
        }

        public int OperationId { get; init; }
    }
}