using RetoSem9.Catalog.Domain;
using RetoSem9.Catalog.Domain.Models.Entities;
using RetoSem9.Shared.Infraestructure.Persistence.Configuration;
using RetoSem9.Shared.Infraestructure.Persistence.Repositories;

namespace RetoSem9.Catalog.Infraestructure;

public class DiscountRepository(CenterContext context) : BaseRepository<Discount>(context), IDiscountRepository
{
    
}