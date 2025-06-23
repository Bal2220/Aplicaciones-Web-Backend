namespace RetoSem9.Catalog.Domain.Models.Entities;

public class Discount
{
    public Discount() {}

    public Discount(string membershipStatus, string productType, float productPriceOriginal)
    {
        MembershipStatus = membershipStatus;
        ProductType = productType;
        ProductPriceOriginal = productPriceOriginal;
        if (ProductType == "book") ProductPriceDiscount = ProductPriceOriginal;
        else if (ProductType == "electronic" && ProductPriceOriginal > 1000) ProductPriceDiscount = ProductPriceOriginal * 0.9f;
        else if (MembershipStatus == "gold") ProductPriceDiscount = ProductPriceOriginal * 0.8f;
        else ProductPriceDiscount = ProductPriceOriginal;
    }

    public int Id { get; set; }
    public string MembershipStatus { get; set; }
    public string ProductType { get; set; }
    public float ProductPriceOriginal { get; set; }
    public float ProductPriceDiscount { get; set; }
}