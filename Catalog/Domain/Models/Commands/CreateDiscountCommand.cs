using RetoSem9.Catalog.Domain.Models.Entities;

namespace RetoSem9.Catalog.Domain.Models.Commands;

public record CreateDiscountCommand
{
    public CreateDiscountCommand(string membershipStatus, string productType, float productPriceOriginal)
    {
        MembershipStatus = membershipStatus.ToLower();
        ProductType = productType.ToLower();
        ProductPriceOriginal = productPriceOriginal;
    }
    
    public string MembershipStatus { get; set; }
    public string ProductType { get; set; }
    public float ProductPriceOriginal { get; set; }
    public float ProductPriceDiscount { get; set; }
}