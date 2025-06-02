namespace ProductLookupService.Domain.Entities.Products.ValueObjects
{
    public record Size
    {

        public Size(double value, SizeUnit unit)
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
        public double Value { get; }
        public SizeUnit Unit { get; }

        public override string ToString()
        {
            return $"{Value:F2} {Unit}";
        }
    }
}
