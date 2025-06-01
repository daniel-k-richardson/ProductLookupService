namespace ProductLookupService.Domain.Products.Entities.ValueObjects;

public record Size
{
    public double Value { get; }
    public SizeUnit Unit { get; }

    private Size(double value, SizeUnit unit)
    {
        if (value < 0)
        {
            throw new ArgumentException("Size value cannot be negative.", nameof(value));
        }

        if (!Enum.IsDefined(unit))
        {
            throw new ArgumentException("Invalid size unit.", nameof(unit));
        }

        Value = value;
        Unit = unit;
    }

    public override string ToString() => $"{Value:F2} {Unit}";
}
