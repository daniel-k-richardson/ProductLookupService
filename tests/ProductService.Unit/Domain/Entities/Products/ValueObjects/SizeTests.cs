using ProductLookupService.Domain.Entities.Products.ValueObjects;

namespace ProductService.Unit.Domain.Entities.Products.ValueObjects
{
    public class SizeTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(-100)]
        public void Constructor_ThrowsArgumentException_WhenValueIsNegative(double input)
        {
            Assert.Throws<ArgumentException>(() => new Size(input, SizeUnit.Gram));
        }

        [Fact]
        public void Constructor_ThrowsArgumentException_WhenUnitIsInvalid()
        {
            // Assuming SizeUnit is an enum and 999 is not a valid value
            Assert.Throws<ArgumentException>(() => new Size(1.0, (SizeUnit)999));
        }

        [Fact]
        public void Constructor_CreatesSize_WhenValid()
        {
            var size = new Size(1.5, SizeUnit.Liter);
            Assert.Equal(1.5, size.Value);
            Assert.Equal(SizeUnit.Liter, size.Unit);
        }
    }
}
