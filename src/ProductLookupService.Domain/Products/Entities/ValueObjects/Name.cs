namespace ProductLookupService.Domain.Products.Entities.ValueObjects;

public record Name(string Value)
{
    public static implicit operator string(Name name) => name.Value;

    public static implicit operator Name(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));
        }

        return new(name);
    }

    public override string ToString() => Value;
}

