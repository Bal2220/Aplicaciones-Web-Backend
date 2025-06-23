using Microsoft.EntityFrameworkCore;
using RetoSem10.Operations.Domain;
using RetoSem10.Operations.Domain.Models.Entities;
using RetoSem10.Shared.Infraestructure.Persistence.Configuration;
using RetoSem10.Shared.Infraestructure.Persistence.Repositories;

namespace RetoSem10.Operations.Infraestructure;

public class OperationRepository(OperationsContext context) : BaseRepository<Operation>(context), IOperationRepository
{
}