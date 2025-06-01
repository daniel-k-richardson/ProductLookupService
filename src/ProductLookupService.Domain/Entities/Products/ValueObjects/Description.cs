namespace ProductLookupService.Domain.Entities.Products.ValueObjects;

public record Description(string Value)
{
    public static implicit operator string(Description description) => description.Value;

    public static implicit operator Description(string description)
    {
        if (string.IsNullOrEmpty(description))
        {
            throw new ArgumentException("Description cannot be null or empty.", nameof(description));
        }

        return new(description);
    }

    public override string ToString() => Value;
}
