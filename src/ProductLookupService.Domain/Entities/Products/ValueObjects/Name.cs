namespace ProductLookupService.Domain.Entities.Products.ValueObjects
{
    public record Name(string Value)
    {
        public static implicit operator string(Name name)
        {
            return name.Value;
        }

        public static implicit operator Name(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }

            return new Name(name);
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
