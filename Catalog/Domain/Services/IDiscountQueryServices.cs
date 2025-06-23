using RetoSem9.Catalog.Domain.Models.Entities;
using RetoSem9.Catalog.Domain.Models.Queries;

namespace RetoSem9.Catalog.Domain.Services;

public interface IDiscountQueryServices
{
    Task<IEnumerable<Discount>> Handler(GetAllDiscount query);
    Task<IEnumerable<string>> Handler(GetAllProductsType query);
    Task<IEnumerable<string>> Handler(GetAllMembershipStatus query);
}