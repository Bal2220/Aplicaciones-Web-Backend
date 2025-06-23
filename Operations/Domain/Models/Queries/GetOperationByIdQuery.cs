namespace RetoSem10.Operations.Domain.Models.Queries
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