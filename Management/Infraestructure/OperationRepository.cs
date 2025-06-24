using RetoSem11.Management.Domain;
using RetoSem11.Management.Domain.Models.Commands;
using RetoSem11.Management.Domain.Models.Entities;
using RetoSem11.Shared.Infraestructure.Persistence.Configuration;
using RetoSem11.Shared.Infraestructure.Persistence.Repositories;

namespace RetoSem11.Management.Interfaces;

public class OperationRepository(OperationContext context) : BaseRepository<Operation>(context), IOperationRepository
{
    
}