using RetoSem9.Catalog.Domain.Models.Commands;
using RetoSem9.Catalog.Domain.Models.Entities;

namespace RetoSem9.Catalog.Domain.Services;

public interface IDiscountCommandServices
{
    Task<Discount> Handler(CreateDiscountCommand command);
}