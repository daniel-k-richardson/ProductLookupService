namespace ProductLookupService.Domain.Entities.Products.ValueObjects;

public record Brand(string Value)
{
    public static implicit operator string(Brand brand) => brand.Value;

    public static implicit operator Brand(string brand)
    {
        if (string.IsNullOrEmpty(brand))
        {
            throw new ArgumentException("Brand cannot be null or empty.", nameof(brand));
        }

        return new(brand);
    }
}
