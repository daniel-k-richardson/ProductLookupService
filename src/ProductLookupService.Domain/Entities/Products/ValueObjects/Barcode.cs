namespace ProductLookupService.Domain.Entities.Products.ValueObjects
{
    public record Barcode
    {

        public Barcode(string value)
        {
            if (value is null or "")
            {
                throw new ArgumentException("Barcode cannot be null or empty.", nameof(value));
            }

            if (!value.All(char.IsDigit))
            {
                throw new ArgumentException("Barcode must contain only digits.", nameof(value));
            }

            if (value.Length is not 8 and not 12 and not 13 and not 14)
            {
                throw new ArgumentException("Barcode must be 8, 12, 13, or 14 digits long.", nameof(value));
            }

            switch (value)
            {
                case { Length: 13 } when !IsValidEan13(value):
                    throw new ArgumentException("Invalid EAN-13 barcode: checksum failed.", nameof(value));
                case { Length: 12 } when !IsValidUpcA(value):
                    throw new ArgumentException("Invalid UPC-A barcode: checksum failed.", nameof(value));
            }

            Value = value;
        }
        public string Value { get; }

        public static implicit operator string(Barcode barcode)
        {
            return barcode.Value;
        }

        public static implicit operator Barcode(string value)
        {
            return new Barcode(value);
        }

        public override string ToString()
        {
            return Value;
        }

        private static bool IsValidEan13(string value)
        {
            // EAN-13: 12 digits + 1 check digit
            var sum = 0;
            for (var i = 0; i < 12; i++)
            {
                var digit = value[i] - '0';
                sum += i % 2 == 0 ? digit : digit * 3;
            }

            var checkDigit = (10 - sum % 10) % 10;

            return checkDigit == value[12] - '0';
        }

        private static bool IsValidUpcA(string value)
        {
            // UPC-A: 11 digits + 1 check digit
            var sum = 0;
            for (var i = 0; i < 11; i++)
            {
                var digit = value[i] - '0';
                sum += i % 2 == 0 ? digit * 3 : digit;
            }

            var checkDigit = (10 - sum % 10) % 10;

            return checkDigit == value[11] - '0';
        }
    }
}
