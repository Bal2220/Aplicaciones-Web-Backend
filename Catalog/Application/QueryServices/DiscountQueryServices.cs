using RetoSem9.Catalog.Domain;
using RetoSem9.Catalog.Domain.Models.Entities;
using RetoSem9.Catalog.Domain.Models.Queries;
using RetoSem9.Catalog.Domain.Services;

namespace RetoSem9.Catalog.Application.QueryServices;

public class DiscountQueryServices : IDiscountQueryServices
{
    private IDiscountRepository _discountRepository;

    public DiscountQueryServices(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }

    public async Task<IEnumerable<Discount>> Handler(GetAllDiscount query)
    {
        return await _discountRepository.ListAsync();
    }

    public async Task<IEnumerable<string>> Handler(GetAllProductsType query)
    {
        var purchases = await _discountRepository.ListAsync();
        return purchases
            .Select(p => p.ProductType.ToLower())
            .Distinct()
            .ToList();
    }

    public async Task<IEnumerable<string>> Handler(GetAllMembershipStatus query)
    {
        var purchases = await _discountRepository.ListAsync();
        return purchases
            .Select(p => p.MembershipStatus.ToLower())
            .Distinct()
            .ToList();
    }
}