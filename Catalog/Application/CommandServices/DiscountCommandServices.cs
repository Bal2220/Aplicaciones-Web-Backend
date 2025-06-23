using RetoSem9.Catalog.Domain;
using RetoSem9.Catalog.Domain.Models.Commands;
using RetoSem9.Catalog.Domain.Models.Entities;
using RetoSem9.Catalog.Domain.Services;
using RetoSem9.Shared.Domain.Repositories;

namespace RetoSem9.Catalog.Application.CommandServices;

public class DiscountCommandServices : IDiscountCommandServices
{
    private readonly IDiscountRepository _discountRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DiscountCommandServices(IDiscountRepository discountRepository, IUnitOfWork unitOfWork)
    {
        _discountRepository = discountRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Discount> Handler(CreateDiscountCommand command)
    {
        var catalog = new Discount(command.MembershipStatus, command.ProductType, command.ProductPriceOriginal);

        await _discountRepository.AddAsync(catalog);

        await _unitOfWork.CompleteAsync();
        
        return catalog;
    }
}